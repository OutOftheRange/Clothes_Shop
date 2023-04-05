using AutoMapper;
using ClothesShop.DatabaseAccess.Entities.UserEntity.User;
using ClothesShop.Services.DTO.Authentication;
using ClothesShop.Services.Interfaces;
using ClothesShopServices.WebAPI.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        IMapper _mapper;
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        ITokenService _tokenService;
        public AuthenticationService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<ResponseData> Register(RegisterData registerData)
        {
            var user = _mapper.Map<User>(registerData);
            user.RegistrationDate = DateTime.Now;

            var result = await _userManager.CreateAsync(user, registerData.Password);
            var responce = new ResponseData();
            if (result.Succeeded)
            {
                responce.Result = true;
                responce.Message = "User has been created successfully";
            }
            else
            {
                responce.Result = false;
                responce.Message = "A problem occurred while creating a user";
            }
            return responce;
        }

        public async Task<ResponseWithTokenData> Login(LoginData loginData)
        {
            var user = await _userManager.FindByEmailAsync(loginData.Email);

            var responce = new ResponseWithTokenData();
            if (user == null)
            {
                responce.Result = false;
                responce.Message = "User with provided email was not founded";
                return responce;
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginData.Password, true, false);

            if(result.Succeeded)
            {
                responce.Result = true;
                responce.Token = _tokenService.GenerateToken(user);
                responce.Message = "Log in was successfully";
            }
            else
            {
                responce.Result = false;
                responce.Message = "A problem occurred while logging in to a user account";
            }
            return responce;
        }
    }
}
