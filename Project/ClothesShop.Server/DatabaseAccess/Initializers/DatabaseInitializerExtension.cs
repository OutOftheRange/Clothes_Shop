﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ClothesShop.DatabaseAccess.Initializers
{
    public static class DbInitializerExtension
    {
        public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ClothesShopDbContext>();
            DbInitializer.Initialize(context);

            return app;
        }
    }
}
