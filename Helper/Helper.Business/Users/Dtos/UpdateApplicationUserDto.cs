using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Helper.Business.Users.Dtos
{
    public class UpdateApplicationUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }     

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
