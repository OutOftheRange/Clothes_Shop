using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ClothesShop.DatabaseAccess.Entities.CartEntity;
using ClothesShop.DatabaseAccess.Entities.CategoryEntity;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using ClothesShop.DatabaseAccess.Entities.PhotosEntity;
using ClothesShop.DatabaseAccess.Entities.UserEntity;

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
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new ItemsConfiguration());
            modelBuilder.ApplyConfiguration(new PhotosConfiguration());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}
