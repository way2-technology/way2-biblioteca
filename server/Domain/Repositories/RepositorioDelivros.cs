using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Interfaces;
using Domain.Responses;
using Newtonsoft.Json.Linq;

namespace Domain.Repositories {
    public class RepositorioDeLivros : IRepositorioDeLivros {
        private readonly string _path;

        public RepositorioDeLivros(string localDoArquivo) {
            _path = localDoArquivo;
        }

        public IEnumerable<Livro> ListeTodos() {
            var conteudo = LeiaConteudoDoArquivo();
            return InterpreteConteudo(conteudo);
        }

        private IEnumerable<Livro> InterpreteConteudo(string conteudo) {
            IEnumerable<dynamic> itensDoArquivo = JArray.Parse(conteudo);
            return itensDoArquivo.Select(livro => new Livro {
                Titulo = (string) livro.Title,
                UrlImagemPequena = (string) livro.SmallImageUrl,
                UrlImagemMedia = (string) livro.ImageUrl,
                Autores = TrateAutores((string) livro.AuthorName),
                ISBN = (string) livro.ISBN,
                Descricao = (string) livro.Description,
                AnoDePublicacao = DateTime.Parse((string) livro.PublicationDate).Year,
                Emprestimo = new[] {
                    new Emprestimo {
                        DataDoEmprestimo = new DateTime(),
                        Nome = string.Empty
                    }
                }
            }).OrderBy(d => d.Titulo);
        }

        private string LeiaConteudoDoArquivo() => System.IO.File.ReadAllText(_path, Encoding.UTF8);

        private string[] TrateAutores(string dadoOriginal) {
            if (dadoOriginal == null) {
                return null;
            }
            return dadoOriginal.Split(',');
        }
    }
}
