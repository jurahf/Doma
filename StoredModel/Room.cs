using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class Room : IEntity
    {
        public Room()
        {
            Photos = new HashSet<RoomPhoto>();
            Commodities = new HashSet<RoomCommodity>();
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }

        public int Count { get; set; }

        public string Description { get; set; }

        public int AdultPlaces { get; set; }

        public int ChildPlaces { get; set; }

        public float Square { get; set; }

        public float CostPerDay { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int RoomCategoryId { get; set; }
        public RoomCategory Category { get; set; }

        public ICollection<RoomPhoto> Photos { get; set; }

        public ICollection<RoomCommodity> Commodities { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
