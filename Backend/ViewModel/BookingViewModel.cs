using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Enums;

namespace ViewModel
{
    public class BookingViewModel : IViewModel
    {
        public BookingViewModel()
        {
            Options = new List<HotelOptionViewModel>();
        }

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ComingTime { get; set; }

        public BookingStatus Status { get; set; }

        public UserViewModel Client { get; set; }

        public RoomViewModel Room { get; set; }

        public FeedbackViewModel Feedback { get; set; }

        public List<HotelOptionViewModel> Options { get; set; }
    }
}
