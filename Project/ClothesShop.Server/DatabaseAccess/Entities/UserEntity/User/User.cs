using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesShop.DatabaseAccess.Entities.CartEntity;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;

namespace ClothesShop.DatabaseAccess.Entities.UserEntity.User
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public bool IsDeactivated { get; set; }
        public float Balance { get; set; }
        public DateTime RegistrationDate { get; set; }

        public List<CartItems> Cart { get; set; } = new List<CartItems>();
        
        public List<Items> Items { get; set; }

    }
}
