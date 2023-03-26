using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothesShop.DatabaseAccess.Entities.CartEntity
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.Items)
                .WithOne(x => x.Cart)
                .HasForeignKey(x => x.CartId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Cart);
        }
    }
}
