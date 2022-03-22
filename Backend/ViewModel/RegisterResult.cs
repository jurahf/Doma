using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Enums;

namespace ViewModel
{
    // в базе не храним
    public class RegisterResult
    {
        public bool Success { get; set; }

        public RegisterError ErrorCode { get; set; }
    }
}
