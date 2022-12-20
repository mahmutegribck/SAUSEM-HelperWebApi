using Helper.Business.Auth.Dtos;
using Helper.Business.Security;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ISecurityService _jwtsecurity;
        private readonly IConfiguration _configuration;
        

        public AuthService(UserManager<IdentityUser> userManager,  ISecurityService jwtsecurity, IConfiguration configuration)
        {
            _userManager = userManager;
            _jwtsecurity = jwtsecurity;
            _configuration = configuration;
    

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
                var claims = new[]
                {
                    new Claim("Email", model.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                };


                _jwtsecurity.SecureToken(claims, out JwtSecurityToken token, out string tokenAstring);


                return new UserManagerResponse
                {
                    Message = tokenAstring,
                    IsSuccess = true,
                    ExpireDate = token.ValidTo
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

                var identityUser = new IdentityUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await _userManager.CreateAsync(identityUser, model.Password);
                if (result.Succeeded)
                {
                    var confirmedEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                    var encodeEmailToken = Encoding.UTF8.GetBytes(confirmedEmailToken);
                    var validEmailToken = WebEncoders.Base64UrlEncode(encodeEmailToken);

                   
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
