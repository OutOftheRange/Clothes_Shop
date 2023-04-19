using ClothesShop.DatabaseAccess.Entities.CartEntity;
using ClothesShop.DatabaseAccess.Entities.CategoryEntity;
using ClothesShop.DatabaseAccess.Entities.ColorsEntity;
using ClothesShop.DatabaseAccess.Entities.PhotosEntity;
using ClothesShop.DatabaseAccess.Entities.SizesEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.Models.ItemsModels
{
    public class ItemsDetailedData
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public int ColorId { get; set; }
        public double Price { get; set; }
        public int SizeId { get; set; }
        public List<string>? Photos { get; set; }
        public int CategoryId { get; set; }
    }
}
