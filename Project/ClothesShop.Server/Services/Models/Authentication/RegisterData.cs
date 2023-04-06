using System.ComponentModel.DataAnnotations;

namespace ClothesShop.Services.Models.Authentication
{
    public class RegisterData
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

    }
}
