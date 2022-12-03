using FluentValidation.AspNetCore;
using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Onion.Api.Helper;
using Api.Core.Repositories;
using Api.Infrastructure.Services;
using Api.Core.Entities;
using Api.Interfaces;
using Api.Api;
using Api.Core.Dtos;

namespace Api.Startup
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterDependencyServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            // services.AddFluentValidation(v => v.RegisterValidatorsFromAssemblyContaining<Program>());
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes("ThisIsMySecretKeyNeverShareToAnyOne25!!"));

            services.AddCors(c =>
            {
                c.AddPolicy("AllowAllPolicy", builder =>
                     builder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader());
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = key

                };
            });
            services.AddAuthorization();

            return services;
        }
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {

            services.AddScoped<IGenericRepository<ProgramType>, ProgramTypeService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
        public static IServiceCollection RegisterApiServices(this IServiceCollection services)
        {

            services.AddScoped<IProgramTypeApi, ProgramTypeApi>();
            return services;
        }
        public static IServiceCollection RegisterDbServices(this IServiceCollection services, WebApplicationBuilder builder)
        {

            var connectionString = builder.Configuration.
            GetConnectionString("Default");
            builder.Services.AddDbContext<AppDbContext>(o
            => o.UseSqlServer(connectionString));
            return services;
        }
    }
}

