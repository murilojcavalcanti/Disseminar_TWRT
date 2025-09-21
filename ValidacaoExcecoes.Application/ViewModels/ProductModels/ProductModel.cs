using ValidacaoExececoes.Core.Entities;

namespace ValidacaoExcecoes.Application.ViewModels.ProductModels
{
    public class ProductModel
    {
        public ProductModel(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public Product ToEntity() => new Product(Nome, Preco);
        public static ProductModel FromEntity(Product product) => new(product.Nome, product.Preco);
    }
}
