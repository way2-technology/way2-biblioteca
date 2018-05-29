using System.Collections.Generic;
using Domain.Responses;

namespace Domain.Interfaces {
    public interface IRepositorioDeLivros
    {
        IEnumerable<Livro> ListeTodos();
    }
}
