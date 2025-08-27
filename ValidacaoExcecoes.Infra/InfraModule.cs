using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValidacaoExcecoes.Infra.Persistence;

namespace ValidacaoExcecoes.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddData(configuration);
            return services;
        }
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            string conString = configuration.GetConnectionString("ProjectConString");
            services.AddDbContext<ProjectDbContext>(opts=>opts.UseSqlServer(conString));
            return services;
        }
    }
}
