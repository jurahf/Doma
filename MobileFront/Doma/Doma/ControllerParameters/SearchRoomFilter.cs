using System;
using System.Collections.Generic;
using System.Text;

namespace Doma.ControllerParameters
{
    public class SearchRoomFilter
    {
        public int? CityId { get; set; }

        public int AdultsCount { get; set; }

        public int ChildrenCount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int Page { get; set; }

        public int Limit { get; set; } 
    }
}
