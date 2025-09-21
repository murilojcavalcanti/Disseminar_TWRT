using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ValidacaoExececoes.Core.Entities;

namespace ValidacaoExcecoes.Infra.Repository.productRepositories
{
    public interface IProductRepository
    {
        Task<Product> Add(Product Produto);
        Task<List<Product>> Get(Expression<Func<Product, bool>> predicate);
    }
}
