using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class HotelHotelOption
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int HotelOptionId { get; set; }
        public HotelOption HotelOption { get; set; }
    }
}
