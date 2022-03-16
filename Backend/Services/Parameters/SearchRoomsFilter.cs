using System;

namespace Services.Parameters
{
    public class SearchRoomsFilter
    {
        public int? CityId { get; set; }

        public int AdultsCount { get; set; }

        public int ChildrenCount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int Page { get; set; } = 0;

        public int Limit { get; set; } = 100;
    }
}
