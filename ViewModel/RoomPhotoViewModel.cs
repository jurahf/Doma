using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class RoomPhotoViewModel : IViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}
