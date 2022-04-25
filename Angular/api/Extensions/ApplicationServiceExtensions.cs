using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Data;
using Angular.implementations;
using Angular.interfaces;
using Angular.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUsers<AppUser>, Users>();
            services.AddDbContext<DataContext>(options =>
           {
               options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
           });
            return services;
        }
    }
}