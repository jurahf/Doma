using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Enums;

namespace ViewModel
{
    public class NotificationViewModel : IViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public NotificationType Type { get; set; }

        public string Title { get; set; }

        public NotificationStatus Status { get; set; }

        public UserViewModel Reciver { get; set; }
    }
}
