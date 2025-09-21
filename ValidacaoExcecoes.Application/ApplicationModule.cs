using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ValidacaoExcecoes.Application.Services.ProductServices;
using ValidacaoExcecoes.Application.ViewModels.ProductModels;

namespace ValidacaoExcecoes.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>().AddValidators() ;
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<ProductModel>();
            return services;
        }
    }
}
