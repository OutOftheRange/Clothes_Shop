using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothesShop.DatabaseAccess.Entities.CartEntity
{
    public class CartItemsConfiguration : IEntityTypeConfiguration<CartItems>
    {
        public void Configure(EntityTypeBuilder<CartItems> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Cart)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Item)
                .WithMany(x => x.CartItem)
                .HasForeignKey(x => x.ItemId);
        }
    }
}
