using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class HotelOption : IEntity
    {
        public HotelOption()
        {
            BookingHotelOptions = new HashSet<BookingHotelOption>();
            HotelHotelOptions = new HashSet<HotelHotelOption>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookingHotelOption> BookingHotelOptions { get; set; }

        public ICollection<HotelHotelOption> HotelHotelOptions { get; set; }
    }
}
