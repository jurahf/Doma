using ViewModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doma.ViewModel
{
    public class LoginResult
    {
        public bool Success { get; set; }

        public LoginError ErrorCode { get; set; }

        public string Token { get; set; }
    }
}
