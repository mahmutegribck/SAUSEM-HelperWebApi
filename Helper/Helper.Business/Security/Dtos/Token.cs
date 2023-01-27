using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Business.Security.Dtos
{
    public class Token
    {
        public string AccessToken { get; set; } //Token 
        public DateTime Expiration { get; set; } //Token omru
    }
}
