using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Interfaces;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Authentication;
using UserService.Infrastructure.Context;
using UserService.Infrastructure.Repositories;

namespace UserService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserService.Application.Interfaces.ITokenServices, UserService.Infrastructure.Authentication.TokenService>();
            return services;
        }
    }
}
