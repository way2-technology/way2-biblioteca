namespace Domain.Responses {
    public class Livro {
        public string Titulo { get; set; }
        public string[] Autores { get; set; }
        public string UrlImagemPequena { get; set; }
        public string UrlImagemMedia { get; set; }
        public string ISBN { get; set; }
        public string Descricao { get; set; }
        public int AnoDePublicacao { get; set; }
        public Emprestimo[] Emprestimo { get; set; }
        public int Quantidade => 1;
    }
}
