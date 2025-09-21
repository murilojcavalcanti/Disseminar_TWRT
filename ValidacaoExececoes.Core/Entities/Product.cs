using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoExececoes.Core.Entities
{
    public class Product
    {
        public Product()
        {
            
        }
        public Product(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
