using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class Commodity : IEntity
    {
        public Commodity()
        {
            RoomCommodities = new HashSet<RoomCommodity>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<RoomCommodity> RoomCommodities { get; set; }
    }
}
