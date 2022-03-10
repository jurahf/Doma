using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class RoomPhoto : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
