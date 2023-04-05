using ClothesShop.DatabaseAccess.Entities.ColorsEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothesShop.DatabaseAccess.Entities.ItemsEntity
{
    public class ColorsConfiguration : IEntityTypeConfiguration<Colors>
    {
        public void Configure(EntityTypeBuilder<Colors> builder)
        {
            builder
                .HasKey(x => x.Id);

        }
    }
}
