using AutoMapper;
using Helper.Business.Answers.Dtos;
using Helper.Business.Auth.Dtos;
using Helper.Business.Auth.ResponseModel;
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

        public AuthService(UserManager<ApplicationUser> userManager, ISecurityService jwtsecurity, IMapper mapper)
        {
            _userManager = userManager;
            _jwtsecurity = jwtsecurity;
            _mapper = mapper;
        }


        public async Task<LoginResponse> LoginUserAsync(LoginDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return new LoginResponse
                    {
                        Message = ErrorMsg.NoUserEmail,
                        IsSuccess = false,
                    };
                }
                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!result)
                    return new LoginResponse
                    {
                        Message = ErrorMsg.InvalidPassword,
                        IsSuccess = false,
                    };
       
                Token token = await _jwtsecurity.CreateAccessToken(user);

                return new LoginResponse
                {
                    Token = token,
                    Message = Msg.LoginSucces,
                    IsSuccess = true,
                    
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RegisterResponse> RegisterUserAsync(RegisterDto model)
        {
            try
            {
                if (model == null)
                {
                    throw new NullReferenceException(ErrorMsg.NullModel);
                }
                if (model.Password != model.ConfirmPassword)
                    return new RegisterResponse
                    {
                        Message = Msg.ConfirmPasswordNotMatch,
                        IsSuccess = false,
                    };

                ApplicationUser newUser = _mapper.Map<ApplicationUser>(model);
                newUser.Id = Guid.NewGuid().ToString();
                newUser.UserName = newUser.Name + " " + newUser.Surname;

                var result = await _userManager.CreateAsync(newUser, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "User");
                    return new RegisterResponse
                    {
                        Message = Msg.UserCreated,
                        IsSuccess = true,
                    };
                }

                return new RegisterResponse
                {
                    Message = ErrorMsg.UserNotCreated,
                    IsSuccess = false,
                    
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LoginResponse> ResetPasswordAsync(ResetPasswordDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                    return new LoginResponse
                    {
                        IsSuccess = false,
                        Message = ErrorMsg.NoUserEmail,
                    };

                if (model.NewPassword != model.ConfirmPassword)
                    return new LoginResponse
                    {
                        IsSuccess = false,
                        Message = ErrorMsg.EmailNotConfirm,
                    };

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

                if (result.Succeeded)
                    return new LoginResponse
                    {
                        Message = Msg.ResetPasswordSuccess,
                        IsSuccess = true,
                    };

                return new LoginResponse
                {
                    Message = ErrorMsg.GeneralErrorMsg,
                    IsSuccess = false
                };
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
