using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Helper.Entites.Identity
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string Name { get; set; }
       
        public string Surname { get; set; }
    }
}
