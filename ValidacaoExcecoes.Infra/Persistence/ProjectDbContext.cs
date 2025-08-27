using Microsoft.EntityFrameworkCore;
using ValidacaoExcecoes.Core.Entities;

namespace ValidacaoExcecoes.Infra.Persistence
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> Opts):base(Opts)
        {
            
        }
        DbSet<User> Users { get; set; }
    }
}
