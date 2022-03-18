using StoredModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class Hotel : IEntity
    {
        public Hotel()
        {
            Feedbacks = new HashSet<Feedback>();
            Rooms = new HashSet<Room>();
            Employees = new HashSet<Employee>();
            HotelOptions = new HashSet<HotelHotelOption>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public HotelType Type { get; set; }

        public float Stars { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<HotelHotelOption> HotelOptions { get; set; }
    }
}
