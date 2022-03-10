using StoredModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel
{
    public class ChatMessage : IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public ChatMessageStatus Status { get; set; }

        public DateTime DateTime { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public int ReciverId { get; set; }
        public User Reciver { get; set; }
    }
}
