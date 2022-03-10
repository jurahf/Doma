using StoredModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public EmployeeRole Role { get; set; }
    }
}
