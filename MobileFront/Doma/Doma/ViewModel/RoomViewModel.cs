using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public int Id { get; set; }

        public int Count { get; set; }

        public string Description { get; set; }

        public int AdultPlaces { get; set; }

        public int ChildPlaces { get; set; }

        public float Square { get; set; }

        public float CostPerDay { get; set; }

        public string MainPhoto
        {
            get
            {
                return Photos.FirstOrDefault()?.Url ?? "";
            }
        }

        public int FreeCount(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null)
                return Count;

            int maxBookingCount = 0;

            for (DateTime date = startDate.Value; date <= endDate.Value; date = date.AddDays(1))
            {
                int bookingCount = Bookings
                    .Where(b => b.Status != Enums.BookingStatus.HotelReject
                        && b.Status != Enums.BookingStatus.ClientCancel)
                    .Where(b => b.StartDate >= date && b.EndDate <= date)
                    .Count();

                if (bookingCount > maxBookingCount)
                    maxBookingCount = bookingCount;
            }

            return Count - maxBookingCount;
        }

        public HotelViewModel Hotel { get; set; }

        public RoomCategoryViewModel Category { get; set; }

        public ICollection<RoomPhotoViewModel> Photos { get; set; }

        public ICollection<CommodityViewModel> Commodities { get; set; }

        public ICollection<BookingViewModel> Bookings { get; set; }
    }
}
