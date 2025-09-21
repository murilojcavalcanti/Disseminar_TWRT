using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValidacaoExcecoes.Infra.Persistence;
using ValidacaoExcecoes.Infra.Repository.productRepositories;

namespace ValidacaoExcecoes.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddData(configuration).AddRepositories();
            return services;
        }
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            string conString = configuration.GetConnectionString("ProjectConString");
            services.AddDbContext<ProjectDbContext>(opts=>opts.UseSqlServer(conString));
            return services;
        }
        public static IServiceCollection AddRepositories (this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
     }
}
