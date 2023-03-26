using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using ClothesShop.DatabaseAccess.Entities.UserEntity;
namespace ClothesShop.DatabaseAccess.Entities.CartEntity
{
    public class Cart
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<Items> Items { get; set; }

        [Required]
        public int ItemsQuantity { get; set; }
    }
}
