using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Data;
using Angular.implementations;
using Angular.interfaces;
using Angular.Models;
using api.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUsers<AppUser>, Users>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
           {
               options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
           });
            return services;
        }
        public static IServiceCollection AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(c =>
           {
               c.AddPolicy("AllowSpecificOrigin",
               options => options.AllowAnyHeader().AllowAnyMethod().
               WithOrigins("https://localhost:4200"));
           });
            return services;
        }
    }
}