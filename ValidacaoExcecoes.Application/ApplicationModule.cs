using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using ValidacaoExcecoes.Application.UserServices;
using ValidacaoExcecoes.Application.Validators;
using ValidacaoExcecoes.Application.ViewModels.UserModels;

namespace ValidacaoExcecoes.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>().AddValidators() ;
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<UserCreateModel>();
            return services;
        }
    }
}
