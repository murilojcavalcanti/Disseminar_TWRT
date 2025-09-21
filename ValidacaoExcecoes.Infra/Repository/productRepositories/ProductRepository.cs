using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ValidacaoExcecoes.Infra.Persistence;
using ValidacaoExececoes.Core.Entities;

namespace ValidacaoExcecoes.Infra.Repository.productRepositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ProjectDbContext _context;

        public ProductRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product Produto)
        {
            _context.Set<Product>().Add(Produto);
            _context.SaveChanges();
            return Produto;
        }

        public async Task<List<Product>> Get(Expression<Func<Product, bool>> predicate)
        {
            List<Product> Products = _context.Set<Product>().Where(predicate).AsNoTracking().ToList();
            return Products;
        }
    }
}
