using System;
using System.Linq;
using Domain.Repositories;
using Domain.Responses;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Domain.Repositories {
    public class RespositorioDeLivosTests {
        private readonly RepositorioDeLivros _repo;

        public RespositorioDeLivosTests() {
            _repo = new RepositorioDeLivros("./Domain/Repositories/livros.json");
        }

        [Fact]
        public void ListeTodos_DeveListarTodosOsRegistrosDoArquivo() {
            var livros = _repo.ListeTodos();
            var expected = new[] { "A Cultura Toyota: A Alma do Modelo Toyota", "A Meta - Um Processo de Melhoria Contínua" };
            var titulos = livros.Select(livro => livro.Titulo).ToArray();
            Assert.All(titulos, item => expected.Contains(item));
        }

        [Fact]
        public void ListeTodos_DeveMapearPropriedadesCorretamente() {
            var expected = new Livro {
                Titulo = "Livro A",
                AnoDePublicacao = 2003,
                Autores = new[] { "Uncle Bob" },
                Descricao = "Descricao do livro A",
                ISBN = "8521312369",
                UrlImagemMedia = "https://images.gr-assets.com/books/1364317608m/17695175m.jpg",
                UrlImagemPequena = "https://images.gr-assets.com/books/1364317608s/17695175s.jpg",
                Emprestimo = new[] {
                    new Emprestimo {
                        DataDoEmprestimo = new DateTime(),
                        Nome = string.Empty
                    }
                }
            };
            var actual = _repo.ListeTodos().First();
            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }
    }
}
