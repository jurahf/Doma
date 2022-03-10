using StoredModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class SupportRequest : IEntity
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Theme { get; set; }

        public string Text { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public SupportRequestStatus Status { get; set; }
    }
}
