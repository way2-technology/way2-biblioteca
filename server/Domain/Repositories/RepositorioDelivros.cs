using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Interfaces;
using Domain.Responses;
using Newtonsoft.Json.Linq;

namespace Domain.Repositories {
    public class RepositorioDeLivros : IRepositorioDeLivros {
        public IEnumerable<Livro> ListeTodos() {
            var content = System.IO.File.ReadAllText("Static/Way2AllBooks.json", Encoding.UTF8);
            dynamic data = JObject.Parse("{value:" + content + "}");
            var items = (IEnumerable<dynamic>) data.value;
            return items.Select(livro => new Livro {
                Titulo = (string) livro.Title,
                UrlImagemPequena = (string) livro.SmallImageUrl,
                UrlImagemMedia = (string) livro.ImageUrl,
                Autores = TrateAutores((string) livro.AuthorName),
                ISBN = (string) livro.ISBN,
                Descricao = (string) livro.Description,
                AnoDePublicacao = DateTime.Parse((string)livro.PublicationDate).Year,
            }).OrderBy(d => d.Titulo);
        }

        private string[] TrateAutores(string rawData) {
            if (rawData == null) {
                return null;
            }
            return rawData.Split(',');
        }
    }
}
