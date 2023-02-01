using Helper.Business.Users.Dtos;
using Helper.Entites.Entites;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Business.Users
{
    public interface IUserService
    {
        Task<List<GetApplicationUserDto>> GetAllUsers();
        Task<GetApplicationUserDto> GetUser(string id);
        Task<IdentityResult> UpdateUser(ApplicationUser user, UpdateApplicationUserDto model);
        Task<IdentityResult> DeleteUser(string id);

    }
}
