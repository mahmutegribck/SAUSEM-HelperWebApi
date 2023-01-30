using Helper.Business.Security.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Business.Auth.ResponseModel
{
    public class LoginResponse
    {
        public Token Token { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

    }
}
