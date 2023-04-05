using Bogus;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using ClothesShop.DatabaseAccess.Entities.CartEntity;
using ClothesShop.DatabaseAccess.Entities.CategoryEntity;
using Microsoft.AspNetCore.Identity;
using ClothesShop.DatabaseAccess.Entities.ColorsEntity;
using ClothesShop.DatabaseAccess.Entities.SizesEntity;
using ClothesShop.DatabaseAccess.Entities.UserEntity.User;

namespace ClothesShop.DatabaseAccess.Seeders
{
    public static class DatabaseSeeder
    {
        public static List<Items> Items = new List<Items>();
        public static List<User> Users = new List<User>();
        public static List<CartItems> CartsItems = new List<CartItems>();

        public static bool IsCalled = false;

        public static List<IdentityRole<Guid>> IdentityRoles = new List<IdentityRole<Guid>>()
        {
            new IdentityRole<Guid>() { Name = "User", NormalizedName = "User" },
            new IdentityRole<Guid>() { Name = "Admin", NormalizedName = "Admin" },
        };

        public static List<IdentityUserRole<Guid>> IdentityUserRoles = new List<IdentityUserRole<Guid>>();

        public static List<Category> Categories = new List<Category>()
        {
            new Category(){ Name = "Coat" },
            new Category(){ Name = "Dress" },
            new Category(){ Name = "Jeans" },
            new Category(){ Name = "Pants " },
            new Category(){ Name = "Shirt" },
            new Category(){ Name = "Tops" },
        };

        public static List<Colors> Colors = new List<Colors>()
        {
            new Colors(){ Name = "Red" },
            new Colors(){ Name = "Orange" },
            new Colors(){ Name = "Yellow" },
            new Colors(){ Name = "Green " },
            new Colors(){ Name = "Blue" },
            new Colors(){ Name = "Purple" },
            new Colors(){ Name = "Pink" },
            new Colors(){ Name = "White" },
        };

        public static List<Sizes> Sizes = new List<Sizes>()
        {
            new Sizes(){ Name = "XS" },
            new Sizes(){ Name = "S" },
            new Sizes(){ Name = "M" },
            new Sizes(){ Name = "L" },
            new Sizes(){ Name = "XL" },
            new Sizes(){ Name = "XXL" }
        };

        public static void Init()
        {
            Randomizer.Seed = new Random(10000);

            var itemsFaker = new Faker<Items>("en")
               .RuleFor(a => a.Info, f => f.Lorem.Paragraph())
               .RuleFor(a => a.Name, f => f.PickRandom(Categories).ToString())
               .RuleFor(a => a.Price, f => f.Random.Double(20, 100))
               .RuleFor(a => a.IsDeactivated, f => f.PickRandom(true, false)) ;

            Items.AddRange(itemsFaker.Generate(9));

            var hasher = new PasswordHasher<User>();
            var appUserFaker = new Faker<User>("en")
               .RuleFor(u => u.Name, f => f.Name.FirstName())
               .RuleFor(u => u.Surname, f => f.Name.LastName())
               .RuleFor(u => u.RegistrationDate, f => f.Date.Past())
               .RuleFor(u => u.IsDeactivated, f => f.PickRandom(true, false))
               .RuleFor(u => u.UserName, (f, p) => f.Internet.UserName(p.Name, p.Surname))
               .RuleFor(u => u.Email, (f, p) => f.Internet.Email(p.Name, p.UserName))
               .RuleFor(u => u.PasswordHash, f => hasher.HashPassword(null, "admin"))
               .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber());

            var users = appUserFaker.Generate(9);
            Users.AddRange(users);
            
            var cartItemsFaker = new Faker<CartItems>()
                .RuleFor(u => u.Name, f => f.Commerce.ProductName());
            CartsItems.AddRange(cartItemsFaker.Generate(4));
        }
    }
}
