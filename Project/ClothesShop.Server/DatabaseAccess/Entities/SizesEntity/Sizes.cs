using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
namespace ClothesShop.DatabaseAccess.Entities.SizesEntity
{
    public class Sizes
    {
        public int Id { get; set; }
        public string Name { get; set;}

        public List<Items> Items = new List<Items>();
    }
}
