using StoredModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class Notification : IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public NotificationType Type { get; set; }

        public string Title { get; set; }

        public NotificationStatus Status { get; set; }

        public int UserId { get; set; }
        public User Reciver { get; set; }
    }
}
