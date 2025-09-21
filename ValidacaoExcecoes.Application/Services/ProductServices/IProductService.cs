using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ValidacaoExcecoes.Application.ViewModels.ProductModels;

namespace ValidacaoExcecoes.Application.Services.ProductServices
{
    public interface IProductService
    {
        Task AddProduct(ProductModel model);
        Task<List<ProductModel>> GetAll(decimal preco=0,string nome="");
    }
}
