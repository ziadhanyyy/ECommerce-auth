using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Interfaces;
using UserService.Application.Services;
using UserService.Application.Validators;
using UserService.Domain.Interfaces;

namespace UserService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
          services.AddScoped<IAuthService, AuthService>();
           services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            return services;
        }
    }
}
