using ClothesShop.DatabaseAccess.Entities.SizesEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothesShop.DatabaseAccess.Entities.ItemsEntity
{
    public class SizesConfiguration : IEntityTypeConfiguration<Sizes>
    {
        public void Configure(EntityTypeBuilder<Sizes> builder)
        {
            builder
                .HasKey(x => x.Id);

        }
    }
}
