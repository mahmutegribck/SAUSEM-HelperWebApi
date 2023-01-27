using AutoMapper;
using Helper.Business.Answers.Dtos;
using Helper.Business.Auth.Dtos;
using Helper.Business.Security;
using Helper.Business.Security.Dtos;
using Helper.Entites;
using Helper.Entites.Entites;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Helper.Business.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ISecurityService _jwtsecurity;       
        private readonly IMapper _mapper;

        public AuthService(UserManager<ApplicationUser> userManager,  ISecurityService jwtsecurity, IMapper mapper)
        {
            _userManager = userManager;
            _jwtsecurity = jwtsecurity;      
            _mapper = mapper;
        }
  

        public async Task<UserManagerResponse> LoginUserAsync(LoginDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return new UserManagerResponse
                    {
                        Message = ErrorMsg.NoUserEmail,
                        IsSuccess = false,
                    };
                }
                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!result)
                    return new UserManagerResponse
                    {
                        Message = ErrorMsg.InvalidPassword,
                        IsSuccess = false,
                    };
               
                Token token = _jwtsecurity.CreateAccessToken(60);

                return new UserManagerResponse
                {
                    Token = token,
                    Message = "Giriş İşlemi Başarılı",
                    IsSuccess = true,
                    ExpireDate = token.Expiration
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterDto model)
        {
            try
            {
                if (model == null)
                {
                    throw new NullReferenceException(ErrorMsg.NullModel);
                }
                if (model.Password != model.ConfirmPassword)
                    return new UserManagerResponse
                    {
                        Message = Msg.ConfirmPasswordNotMatch,
                        IsSuccess = false,
                    };

                ApplicationUser newUser = _mapper.Map<ApplicationUser>(model);
                newUser.Id = Guid.NewGuid().ToString();
                newUser.UserName = newUser.Name + " " + newUser.Surname;

                //ApplicationRole role = await _roleManager.FindByNameAsync("User");
                

                var result = await _userManager.CreateAsync(newUser, model.Password);
                
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "User");
                    return new UserManagerResponse
                    {
                        Message = Msg.UserCreated,
                        IsSuccess = true,
                    };
                }

                return new UserManagerResponse
                {
                    Message = ErrorMsg.UserNotCreated,
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description)
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                    return new UserManagerResponse
                    {
                        IsSuccess = false,
                        Message = ErrorMsg.NoUserEmail,
                    };

                if (model.NewPassword != model.ConfirmPassword)
                    return new UserManagerResponse
                    {
                        IsSuccess = false,
                        Message = ErrorMsg.EmailNotConfirm,
                    };

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

                if (result.Succeeded)
                    return new UserManagerResponse
                    {
                        Message = Msg.ResetPasswordSuccess,
                        IsSuccess = true,
                    };

                return new UserManagerResponse
                {
                    Message = ErrorMsg.GeneralErrorMsg,
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description),
                };
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
