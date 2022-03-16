using Doma.ControllerParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Doma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HotelDetailsPage : ContentPage
    {
        public List<RoomPhotoViewModel> AllPhotos { get; set; }


        public HotelDetailsPage(HotelViewModel hotel, RoomViewModel room, SearchRoomFilter filter)
        {
            InitializeComponent();
            
            Title = hotel.Name;
            AllPhotos = hotel.Rooms.SelectMany(x => x.Photos).ToList();
            carousel.ItemsSource = AllPhotos;

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                carousel.Position = (carousel.Position + 1) % AllPhotos.Count;

                return true;
            });
        }
    }
}