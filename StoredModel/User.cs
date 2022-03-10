using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class User : IEntity
    {
        public User()
        {
            Employees = new HashSet<Employee>();
            Bookings = new HashSet<Booking>();
            IncomingMessages = new HashSet<ChatMessage>();
            OutcomingMessages = new HashSet<ChatMessage>();
            Notifications = new HashSet<Notification>();
            SupportRequests = new HashSet<SupportRequest>();
        }

        public int Id { get; set; } 

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public ICollection<ChatMessage> IncomingMessages { get; set; }

        public ICollection<ChatMessage> OutcomingMessages { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<SupportRequest> SupportRequests { get; set; }
    }
}
