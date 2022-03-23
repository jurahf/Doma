using ViewModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doma.ViewModel
{
    public class RegisterResult
    {
        public bool Success { get; set; }

        public RegisterError ErrorCode { get; set; }
    }
}
