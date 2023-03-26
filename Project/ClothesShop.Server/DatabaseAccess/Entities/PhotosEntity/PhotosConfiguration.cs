using ClothesShop.DatabaseAccess.Entities.PhotosEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothesShop.DatabaseAccess.Entities.PhotosEntity
{
    public class PhotosConfiguration : IEntityTypeConfiguration<Photos>
    {
        public void Configure(EntityTypeBuilder<Photos> builder)
        {
            builder
                .HasKey(x => x.Id);
        }
    }
}
