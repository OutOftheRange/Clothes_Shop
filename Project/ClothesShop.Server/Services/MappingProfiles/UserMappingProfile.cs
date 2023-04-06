using AutoMapper;
using ClothesShop.DatabaseAccess.Entities.UserEntity.User;
using ClothesShop.Services.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterData, User>()
                .ForMember(src => src.UserName, opt =>
                {
                    opt.MapFrom(src => src.Email);
                });
        }
    }
}
