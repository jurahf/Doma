using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class Feedback : IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public float Estimate { get; set; }

        public DateTime DateTime { get; set; }

        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
