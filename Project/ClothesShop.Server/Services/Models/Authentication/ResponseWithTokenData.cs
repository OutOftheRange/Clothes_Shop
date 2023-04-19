using ClothesShopServices.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.Models.Authentication
{
    public class ResponseWithTokenData : ResponceData
    {
        public string? Token { get; set; }
    }
}
