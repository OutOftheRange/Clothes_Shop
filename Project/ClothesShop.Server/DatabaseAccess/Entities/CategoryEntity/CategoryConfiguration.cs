using ClothesShop.DatabaseAccess.Entities.CategoryEntity;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothesShop.DatabaseAccess.Entities.CategoryEntity
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(x => x.Id);
        }
    }
}
