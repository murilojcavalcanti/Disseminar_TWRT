using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ValidacaoExcecoes.Application.ViewModels.ProductModels;
using ValidacaoExcecoes.Infra.Repository.productRepositories;
using ValidacaoExececoes.Core.Entities;

namespace ValidacaoExcecoes.Application.Services.ProductServices
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task AddProduct(ProductModel model)
        {
            var product = model.ToEntity();
            await productRepository.Add(product);
        }

        public async Task<List<ProductModel>> GetAll(decimal preco=0,string nome="")
        {
            List<Product> products = new();
            if (preco > 0 && string.IsNullOrEmpty(nome))
            {
                products = await productRepository.Get(p => p.Preco == preco);   
            }
            else if (preco == 0 && !string.IsNullOrEmpty(nome))
            {
                products = await productRepository.Get(p => p.Nome.Contains(nome));
            }
            else if (preco > 0 && !string.IsNullOrEmpty(nome))
            {
                products = await productRepository.Get(p => p.Preco == preco && p.Nome.Contains(nome));
            }
            else
            {
                products = await productRepository.Get(p=>true);
            }
            return products.Select(p => ProductModel.FromEntity(p)).ToList();
        }
        public async Task<ProductModel> Get(int Id)
        {
            List<Product> products = await productRepository.Get(p => p.Id == Id);
            return ProductModel.FromEntity(products.First());
        }
    }
}
