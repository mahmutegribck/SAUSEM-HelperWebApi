using Helper.Business.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Business.Auth
{
    public interface IAuthService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterDto model);
        Task<UserManagerResponse> LoginUserAsync(LoginDto model);

        Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordDto model);

    }
}
