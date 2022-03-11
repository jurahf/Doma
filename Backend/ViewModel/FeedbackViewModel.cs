using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class FeedbackViewModel : IViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public float Estimate { get; set; }

        public DateTime DateTime { get; set; }

        public BookingViewModel Booking { get; set; }

        public HotelViewModel Hotel { get; set; }
    }
}
