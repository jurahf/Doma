using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class RoomCommodity
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int CommodityId { get; set; }
        public Commodity Commodity { get; set; }
    }
}
