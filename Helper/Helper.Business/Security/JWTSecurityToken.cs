using Helper.Business.Security.Dtos;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Business.Security
{
    public class JWTSecurityToken : ISecurityService
    {
		private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        public JWTSecurityToken(IConfiguration configuration, UserManager<ApplicationUser> userManager) 
		{
			_configuration = configuration;
			_userManager = userManager;
		}

        public async Task<Token> CreateAccessToken(ApplicationUser user)
        {
			Token token = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Key"]));
			SigningCredentials signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),   

            }.Union(roleClaims);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
			(
				audience: _configuration["Authentication:Audience"],
                issuer: _configuration["Authentication:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
				notBefore: DateTime.UtcNow,
				signingCredentials: signingCredentials
            );

			JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
			return token;
        }
    }
}
