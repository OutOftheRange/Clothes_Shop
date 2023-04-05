using System;
using ClothesShop.DatabaseAccess.Entities.CartEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothesShop.DatabaseAccess.Entities.UserEntity.User
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.RegistrationDate)
                .HasDefaultValue(DateTime.Now);

        }
    }
}
