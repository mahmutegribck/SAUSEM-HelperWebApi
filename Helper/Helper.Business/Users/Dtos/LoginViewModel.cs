using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Helper.Business.Users.Dtos
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre zoruldur.")]
        public string Password { get; set; }
    }
}
