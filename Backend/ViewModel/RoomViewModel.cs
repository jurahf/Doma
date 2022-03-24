using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class RoomViewModel : IViewModel
    {
        public RoomViewModel()
        {
            Photos = new HashSet<RoomPhotoViewModel>();
            Commodities = new HashSet<CommodityViewModel>();
            Bookings = new HashSet<BookingViewModel>();
            Likes = new HashSet<LikeViewModel>();
        }

        public int Id { get; set; }

        public int Count { get; set; }

        public string Description { get; set; }

        public int AdultPlaces { get; set; }

        public int ChildPlaces { get; set; }

        public float Square { get; set; }

        public float CostPerDay { get; set; }

        public HotelViewModel Hotel { get; set; }

        public RoomCategoryViewModel Category { get; set; }

        public ICollection<RoomPhotoViewModel> Photos { get; set; }

        public ICollection<CommodityViewModel> Commodities { get; set; }

        public ICollection<BookingViewModel> Bookings { get; set; }

        public ICollection<LikeViewModel> Likes { get; set; }
    }
}
