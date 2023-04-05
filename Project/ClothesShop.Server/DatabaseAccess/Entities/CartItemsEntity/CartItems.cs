using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using ClothesShop.DatabaseAccess.Entities.UserEntity.User;

namespace ClothesShop.DatabaseAccess.Entities.CartEntity
{
    public class CartItems
    {        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }   

        public Guid UserId { get; set; }
        public User User { get; set; }

        public int ItemId { get; set; }
        public Items Item { get; set; }

    }
}
