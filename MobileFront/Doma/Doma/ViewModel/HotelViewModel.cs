using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Enums;

namespace ViewModel
{
    public class HotelViewModel : IViewModel
    {
        public HotelViewModel()
        {
            Feedbacks = new List<FeedbackViewModel>();
            Rooms = new List<RoomViewModel>();
            Employees = new List<EmployeeViewModel>();
            HotelOptions = new List<HotelOptionViewModel>();
            Likes = new List<LikeViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public CityViewModel City { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public HotelType Type { get; set; }

        public float Stars { get; set; }

        public List<FeedbackViewModel> Feedbacks { get; set; }

        public List<RoomViewModel> Rooms { get; set; }

        public List<EmployeeViewModel> Employees { get; set; }

        public List<HotelOptionViewModel> HotelOptions { get; set; }

        public List<LikeViewModel> Likes { get; set; }
    }
}
