using ClothesShopServices.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.DTO.Authentication
{
    public class ResponseWithTokenData : ResponseData
    {
        public string? Token { get; set; }
    }
}
