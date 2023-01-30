using Helper.Business.Security.Dtos;
using Helper.Entites.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Business.Security
{
    public interface ISecurityService
    {    
        Task<Token> CreateAccessToken(ApplicationUser user);
    }
}
