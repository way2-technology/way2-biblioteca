using System.Collections.Generic;
using Domain.Entities;

namespace Api.Models.Util {

    public class CategoryLocalization {

        private static readonly Dictionary<Category, string> _categories = new Dictionary<Category, string>() {
            //[Category.Literature] = "Literatura",
            //[Category.Technical] = "Técnico",
            //[Category.Development] = "Desenvolvimento",
            //[Category.Business] = "Negócios",
            //[Category.Process] = "Processos",
            //[Category.Selling] = "Vendas",
            //[Category.Marketing] = "Marketing",
            //[Category.Accounting] = "Contabilidade",
            //[Category.HumanResource] = "Recursos Humanos",
            //[Category.Network] = "Redes",
            //[Category.Law] = "Direito",
            //[Category.Management] = "Gestão",
            //[Category.Testing] = "Testes",
            //[Category.Entrepreneurship] = "Empreendedorismo",
            //[Category.Energy] = "Energia",
            //[Category.DevOps] = "DevOps",
            //[Category.HelpDesk] = "Suporte",
            //[Category.Finance] = "Finanças",
            //[Category.SoftwareArchitecture] = "Arquitetura",
            //[Category.Database] = "Bancos de Dados",
            //[Category.BigData] = "Big Data",
        };

        public static string Translate(Category category) => _categories[category];
    }
}