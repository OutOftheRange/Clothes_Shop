using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClothesShop.DatabaseAccess.Entities.CartEntity;

namespace ClothesShop.DatabaseAccess.Entities.ItemsEntity
{
    public class ItemsConfiguration : IEntityTypeConfiguration<Items>
    {
        public void Configure(EntityTypeBuilder<Items> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.Photos)
                .WithOne(x => x.Item)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Size)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.SizeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Color)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.ColorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.CartItem)
                .WithOne(x => x.Item)
                .HasForeignKey<CartItems>(x => x.ItemId);
        }
    }
}
