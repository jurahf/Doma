using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class UserViewModel : IViewModel
    {
        public UserViewModel()
        {
            Employees = new List<EmployeeViewModel>();
            Bookings = new List<BookingViewModel>();
            IncomingMessages = new List<ChatMessageViewModel>();
            OutcomingMessages = new List<ChatMessageViewModel>();
            Notifications = new List<NotificationViewModel>();
            SupportRequests = new List<SupportRequestViewModel>();
            Likes = new List<LikeViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public List<EmployeeViewModel> Employees { get; set; }

        public List<BookingViewModel> Bookings { get; set; }

        public List<ChatMessageViewModel> IncomingMessages { get; set; }

        public List<ChatMessageViewModel> OutcomingMessages { get; set; }

        public List<NotificationViewModel> Notifications { get; set; }

        public List<SupportRequestViewModel> SupportRequests { get; set; }

        public List<LikeViewModel> Likes { get; set; }
    }
}
