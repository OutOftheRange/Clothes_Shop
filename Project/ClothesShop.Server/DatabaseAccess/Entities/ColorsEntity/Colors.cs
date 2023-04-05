using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;

namespace ClothesShop.DatabaseAccess.Entities.ColorsEntity
{
    public class Colors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Items> Items { get; set; } = new List<Items>();
    }
}
