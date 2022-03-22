using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Enums;

namespace Services.Parameters
{
    public class RegistrationRequest
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}
