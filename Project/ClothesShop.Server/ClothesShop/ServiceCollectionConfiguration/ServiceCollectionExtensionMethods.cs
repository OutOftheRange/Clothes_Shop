using AutoMapper;
using ClothesShop.DatabaseAccess.Interfaces.ItemsRepository;
using ClothesShop.DatabaseAccess.Repositories.Items;
using ClothesShop.DatabaseAccess.Repositories.ItemsRepository;
using ClothesShop.Services.Interfaces;
using ClothesShop.Services.MappingProfiles;
using ClothesShop.Services.Services;
using ClothesShop.Services.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClothesShop.WebAPI.ServiceCollectionConfiguration
{
    public static class ServiceCollectionExtensionMethods
    {
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = configuration.GetSection("jwtConfig");
            var key = jwtConfig["key"];
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig["Issuer"],
                    ValidAudience = jwtConfig["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

        }

        public static void ConfigureMapping(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<UserMappingProfile>();
                map.AddProfile<ItemsMappingProfile>();
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }

        public static void BindServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IItemsService, ItemsService>();
            services.AddTransient<IReadItemsRepository, ReadItemsRepository>();
            services.AddTransient<IWriteItemsRepository, WriteItemsRepository>();

        }

        public static void ConfigureValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<RegistrationForm>(ServiceLifetime.Transient);
        }
    }
}

