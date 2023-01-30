using Helper.Business.Auth.Dtos;
using Helper.Business.Auth.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Business.Auth
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterUserAsync(RegisterDto model);
        Task<LoginResponse> LoginUserAsync(LoginDto model);

        Task<LoginResponse> ResetPasswordAsync(ResetPasswordDto model);

    }
}
