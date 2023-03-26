using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;

namespace ClothesShop.DatabaseAccess.Entities.PhotosEntity
{
    public class Photos
    {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public Items Item { get; set; }

        public string Data { get; set; }
    }
}
