using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Enums;

namespace ViewModel
{
    public class SupportRequestViewModel : IViewModel
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Theme { get; set; }

        public string Text { get; set; }

        public UserViewModel User { get; set; }

        public SupportRequestStatus Status { get; set; }
    }
}
