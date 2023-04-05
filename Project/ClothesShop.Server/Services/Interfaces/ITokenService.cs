using ClothesShop.DatabaseAccess.Entities.UserEntity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
