using Microsoft.EntityFrameworkCore;
using ValidacaoExececoes.Core.Entities;

namespace ValidacaoExcecoes.Infra.Persistence
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> Opts):base(Opts)
        {
            
        }
        DbSet<Product> Products { get; set; }
    }
}
