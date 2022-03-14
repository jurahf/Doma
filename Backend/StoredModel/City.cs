using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class City : IEntity
    {
        public City()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public ICollection<Hotel> Hotels { get; set; }
    }
}
