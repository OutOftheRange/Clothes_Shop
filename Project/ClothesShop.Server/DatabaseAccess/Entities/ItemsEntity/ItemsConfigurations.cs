using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                .HasForeignKey(x => x.CategoryId);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.UserId);

        }
    }
}
