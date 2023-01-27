using Helper.Business.Security.Dtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
		private readonly IConfiguration _configuration;
		public JWTSecurityToken(IConfiguration configuration) 
		{
			_configuration = configuration;
		}

		//public IConfiguration Configuration { get; }

        public Token CreateAccessToken(int minute)
        {
			Token token = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Key"]));

			SigningCredentials signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

			token.Expiration = DateTime.UtcNow.AddMinutes(minute);
			JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
			(
				audience: _configuration["Authentication:Audience"],
                issuer: _configuration["Authentication:Issuer"],
                expires: token.Expiration,
				notBefore: DateTime.UtcNow,
				signingCredentials: signingCredentials
            );
			JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
			return token;
        }

   //     public void SecureToken(Claim[] claims, out JwtSecurityToken token, out string tokenAstring)
   //     {
			//try
			//{
				
			//	var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:Key"]));
			//	token = new JwtSecurityToken
			//	( 
			//		//issuer: Configuration["Authentication:Issuer"],
			//		//audience: Configuration["Authentication:Audience"],
			//		claims: claims,
			//		expires: DateTime.Now.AddMinutes(15),
			//		signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)


			//	);
			//	tokenAstring = new JwtSecurityTokenHandler().WriteToken(token);


			//}
			//catch (Exception)
			//{

			//	throw;
			//}
   //     }
    }
}
