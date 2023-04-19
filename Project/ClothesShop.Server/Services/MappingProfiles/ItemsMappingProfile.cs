using AutoMapper;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using ClothesShop.DatabaseAccess.Entities.UserEntity.User;
using ClothesShop.Services.Models.Authentication;
using ClothesShop.Services.Models.ItemsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.MappingProfiles
{
    public class ItemsMappingProfile : Profile
    {
        public ItemsMappingProfile()
        {
            CreateMap<Items, ItemsDetailedData>();
            
            CreateMap<ItemsDetailedData, Items>();

        }
    }
}
