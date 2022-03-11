using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class BookingHotelOption
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        public int HotelOptionId { get; set; }
        public HotelOption HotelOption { get; set; }
    }
}
