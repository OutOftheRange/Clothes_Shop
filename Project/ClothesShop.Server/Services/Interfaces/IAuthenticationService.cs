using ClothesShop.Services.Models.Authentication;
using ClothesShopServices.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResponceData> Register(RegisterData registerData);
        Task<ResponseWithTokenData> Login(LoginData loginData);
    }
}
