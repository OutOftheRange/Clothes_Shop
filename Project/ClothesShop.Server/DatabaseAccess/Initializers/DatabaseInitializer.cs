using ClothesShop.DatabaseAccess.Seeders;
using Microsoft.AspNetCore.Identity;

namespace ClothesShop.DatabaseAccess.Initializers
{
    public class DbInitializer
    {
        public static void Initialize(ClothesShopDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Items.Any())
            {
                return;
            } 

            DatabaseSeeder.Init();

            context.Categories.AddRange(DatabaseSeeder.Categories);
            context.Colors.AddRange(DatabaseSeeder.Colors);
            context.Sizes.AddRange(DatabaseSeeder.Sizes);
            context.Users.AddRange(DatabaseSeeder.Users);
            context.Roles.AddRange(DatabaseSeeder.IdentityRoles);
            context.SaveChanges();

            foreach (var user in DatabaseSeeder.Users)
            {
                if (user == DatabaseSeeder.Users.Last())
                {
                    context.UserRoles.Add(new IdentityUserRole<Guid>
                    {
                        UserId = user.Id,
                        RoleId = DatabaseSeeder.IdentityRoles.Last().Id
                    });
                    continue;
                }
                context.UserRoles.Add(new IdentityUserRole<Guid>
                {
                    UserId = user.Id,
                    RoleId = DatabaseSeeder.IdentityRoles.First().Id
                });
                user.Balance = 500;
            }

            foreach (var item in DatabaseSeeder.Items)
            {
                item.CategoryId = DatabaseSeeder.Categories[Random.Shared.Next(0, DatabaseSeeder.Categories.Count)].Id;
                item.ColorId = DatabaseSeeder.Colors[Random.Shared.Next(0, DatabaseSeeder.Colors.Count)].Id;
                item.SizeId = DatabaseSeeder.Sizes[Random.Shared.Next(0, DatabaseSeeder.Sizes.Count)].Id;
            }
            context.Items.AddRange(DatabaseSeeder.Items);
            context.SaveChanges();

            foreach (var cartItem in DatabaseSeeder.CartsItems)
            {
                cartItem.UserId = DatabaseSeeder.Users[Random.Shared.Next(0, DatabaseSeeder.Users.Count)].Id;
                cartItem.ItemId = DatabaseSeeder.Items[Random.Shared.Next(0, DatabaseSeeder.Items.Count)].Id;
            }
            context.CartItems.AddRange(DatabaseSeeder.CartsItems);
            context.SaveChanges();
        }
    }
}
