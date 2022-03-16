using Doma.ControllerParameters;
using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Doma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultListPage : ContentPage
    {
        private readonly IHotelRemoteService hotelService;
        private SearchRoomFilter filter;

        public List<RoomViewModel> SearchList { get; set; }

        public int Days
        {
            get { return (filter.EndDate - filter.StartDate)?.Days ?? 1; }
        }

        public SearchResultListPage(
            List<RoomViewModel> searchList, 
            SearchRoomFilter filter,
            IHotelRemoteService hotelService)
        {
            InitializeComponent();

            this.SearchList = searchList;   // TODO: группировать по отелям
            this.filter = filter;
            this.hotelService = hotelService;
            MyListView.ItemsSource = SearchList;
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            MyListView.SelectedItem = null;

            RoomViewModel room = e.Item as RoomViewModel;
            HotelViewModel hotel = await hotelService.Get(room.Hotel.Id);

            await Navigation.PushAsync(new HotelDetailsPage(hotel, room, filter));
        }
    }
}
