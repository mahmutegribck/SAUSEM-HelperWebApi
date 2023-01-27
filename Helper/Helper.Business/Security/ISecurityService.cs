using Helper.Business.Security.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Helper.Business.Security
{
    public interface ISecurityService
    {
        //void SecureToken(Claim[] claims, out JwtSecurityToken token, out string tokenAstring);
        Token CreateAccessToken(int minute);
        
    }
}
