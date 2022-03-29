using Doma.Authorization;
using Doma.RemoteServices.ServiceDeclarations;
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
    public partial class FaivoritesPage : BaseViewWithAuth
    {
        private readonly ILikeRemoteService likeService;
        private readonly IHotelRemoteService hotelService;
        private readonly IRoomRemoteService roomService;
        private List<RoomViewModel> rooms = new List<RoomViewModel>();

        public FaivoritesPage(
            ICurrentUserProvider userProvider, 
            ILikeRemoteService likeService,
            IHotelRemoteService hotelService,
            IRoomRemoteService roomService)
            : base(userProvider)
        {
            this.likeService = likeService;
            this.hotelService = hotelService;
            this.roomService = roomService;

            InitializeComponent();
        }

        protected override async void ShowFilledView()
        {
            var likes = await likeService.GetByUser(userProvider.CurrentUser.Id);
            rooms = likes.Select(x => x.Room).ToList();

            MyListView.ItemsSource = rooms;

            mainContent.IsVisible = true;
        }

        protected override void ShowNotAuthView()
        {
            mainContent.IsVisible = false;
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            MyListView.SelectedItem = null;

            RoomViewModel room = await roomService.Get((e.Item as RoomViewModel).Id);
            HotelViewModel hotel = await hotelService.Get(room.Hotel.Id);

            await Navigation.PushAsync(new HotelDetailsPage(hotel, room, null, likeService, userProvider));
        }
    }
}