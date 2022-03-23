using ViewModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doma.ControllerParameters
{
    public class RegistrationRequest
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}
