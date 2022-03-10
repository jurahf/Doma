using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class RoomCategory : IEntity
    {
        public RoomCategory()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
