using AutoMapper;
using ClothesShop.DatabaseAccess.Entities.UserEntity.User;
using ClothesShop.Services.DTO.Authentication;
using ClothesShop.Services.Interfaces;
using ClothesShopServices.WebAPI.DTO;
using Microsoft.AspNetCore.Identity;

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
            var response = new ResponseData();
            if (result.Succeeded)
            {
                response.Result = true;
                response.Message = "User has been created successfully";
            }
            else
            {
                response.Result = false;
                response.Message = "A problem occurred while creating a user";
            }
            return response;
        }

        public async Task<ResponseWithTokenData> Login(LoginData loginData)
        {
            var user = await _userManager.FindByEmailAsync(loginData.Email);

            var response = new ResponseWithTokenData();
            if (user == null)
            {
                response.Result = false;
                response.Message = "User with provided email was not founded";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginData.Password, true, false);

            if(result.Succeeded)
            {
                response.Result = true;
                response.Token = _tokenService.GenerateToken(user);
                response.Message = "Log in was successfully";
            }   
            else
            {
                response.Result = false;
                response.Message = "A problem occurred while logging in to a user account";
            }
            return response;
        }
    }
}
