using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ClothesShop.DatabaseAccess.Entities.CartEntity;
using ClothesShop.DatabaseAccess.Entities.CategoryEntity;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using ClothesShop.DatabaseAccess.Entities.PhotosEntity;
using ClothesShop.DatabaseAccess.Entities.UserEntity;
using ClothesShop.DatabaseAccess.Entities.ColorsEntity;
using ClothesShop.DatabaseAccess.Entities.SizesEntity;
using ClothesShop.DatabaseAccess.Entities.UserEntity.User;

namespace ClothesShop.DatabaseAccess
{
    public class ClothesShopDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {

        public ClothesShopDbContext(DbContextOptions<ClothesShopDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemsConfiguration());
            modelBuilder.ApplyConfiguration(new ItemsConfiguration());
            modelBuilder.ApplyConfiguration(new PhotosConfiguration());
            modelBuilder.ApplyConfiguration(new SizesConfiguration());
            modelBuilder.ApplyConfiguration(new ColorsConfiguration());
                
        }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Sizes> Sizes { get; set; }

    }
}
