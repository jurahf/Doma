using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Enums;

namespace ViewModel
{
    public class EmployeeViewModel : IViewModel
    {
        public int Id { get; set; }

        public UserViewModel User { get; set; }

        public HotelViewModel Hotel { get; set; }

        public EmployeeRole Role { get; set; }
    }
}
