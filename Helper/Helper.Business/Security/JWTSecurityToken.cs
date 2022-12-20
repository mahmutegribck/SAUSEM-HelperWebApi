using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Helper.Business.Security
{
    public class JWTSecurityToken : ISecurityService
    {
		public JWTSecurityToken(IConfiguration configuration) 
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
        public void SecureToken(Claim[] claims, out JwtSecurityToken token, out string tokenAstring)
        {
			try
			{
				
				var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:Key"]));
				token = new JwtSecurityToken
				( 
					issuer: Configuration["Authentication:Issuer"],
					audience: Configuration["Authentication:Audience"],
					claims: claims,
					expires: DateTime.Now.AddMinutes(15),
					signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)


				);
				tokenAstring = new JwtSecurityTokenHandler().WriteToken(token);


			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
