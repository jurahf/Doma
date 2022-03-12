using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Enums;

namespace ViewModel
{
    public class ChatMessageViewModel : IViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public ChatMessageStatus Status { get; set; }

        public DateTime DateTime { get; set; }

        public UserViewModel Author { get; set; }

        public UserViewModel Reciver { get; set; }
    }
}
