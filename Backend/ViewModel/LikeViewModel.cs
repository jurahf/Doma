using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class LikeViewModel : IViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public RoomViewModel Room { get; set; }

        public UserViewModel User { get; set; }
    }
}
