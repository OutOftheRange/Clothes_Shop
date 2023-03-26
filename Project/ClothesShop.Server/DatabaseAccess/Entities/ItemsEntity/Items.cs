using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesShop.DatabaseAccess.Entities.PhotosEntity;
using ClothesShop.DatabaseAccess.Entities.CategoryEntity;
using ClothesShop.DatabaseAccess.Entities.CartEntity;
using ClothesShop.DatabaseAccess.Entities.UserEntity;

namespace ClothesShop.DatabaseAccess.Entities.ItemsEntity
{
    public class Items
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Info { get; set; }
        public string Color { get; set; }
        [Required]
        public float Price { get; set; }
        public float Size { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public List<Photos> Photos { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
