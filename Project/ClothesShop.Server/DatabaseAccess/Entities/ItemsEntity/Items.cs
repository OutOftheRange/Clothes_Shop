using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesShop.DatabaseAccess.Entities.PhotosEntity;
using ClothesShop.DatabaseAccess.Entities.CategoryEntity;
using ClothesShop.DatabaseAccess.Entities.CartEntity;
using ClothesShop.DatabaseAccess.Entities.ColorsEntity;
using ClothesShop.DatabaseAccess.Entities.SizesEntity;

namespace ClothesShop.DatabaseAccess.Entities.ItemsEntity
{
    public class Items
    {
        public int Id { get; set; }
        public bool IsDeactivated { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Info { get; set; }

        public int ColorId { get; set; } 
        public Colors Color { get; set; }

        [Required]
        public double Price { get; set; }

        public int SizeId { get; set; }
        public Sizes Size { get; set; }

        public List<CartItems> CartItem { get; set; } = new List<CartItems>();

        public List<Photos> Photos { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
