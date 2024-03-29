﻿using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DatabaseAccess.Entities.CategoryEntity
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Items> Items { get; set; } = new List<Items>();
    }
}
