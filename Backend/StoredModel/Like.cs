using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class Like : IEntity
    {
        public int Id { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime Date { get; set; }
    }
}
