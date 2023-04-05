﻿using ClothesShop.Services.DTO.Authentication;
using ClothesShopServices.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResponseData> Register(RegisterData registerData);
        Task<ResponseWithTokenData> Login(LoginData loginData);
    }
}
