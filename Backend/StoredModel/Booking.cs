using StoredModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class Booking : IEntity
    {
        public Booking()
        {
            Options = new HashSet<BookingHotelOption>();
        }

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ComingTime { get; set; }

        public BookingStatus Status { get; set; }

        public int UserId { get; set; }
        public User Client { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public Feedback Feedback { get; set; }

        public ICollection<BookingHotelOption> Options { get; set; }
    }
}
