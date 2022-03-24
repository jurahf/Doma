using Doma.Authorization;
using Doma.ControllerParameters;
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
    public partial class HotelDetailsPage : ContentPage
    {
        private readonly ILikeRemoteService likeService;
        private readonly ICurrentUserProvider userProvider;


        public List<RoomPhotoViewModel> AllPhotos { get; set; }

        private HotelViewModel hotel { get; set; }

        private RoomViewModel room { get; set; }

        private string likeButtonText { get; set; }

        public HotelDetailsPage(
            HotelViewModel hotel,
            RoomViewModel room,
            SearchRoomFilter filter,
            ILikeRemoteService likeService,
            ICurrentUserProvider userProvider)
        {
            this.hotel = hotel;
            this.room = room;
            this.likeService = likeService;
            this.userProvider = userProvider;

            InitializeComponent();

            UpdateLikeButtonText();

            roomsListView.ItemsSource = hotel.Rooms;
            Title = hotel.Name;
            AllPhotos = hotel.Rooms.SelectMany(x => x.Photos).ToList();
            carousel.ItemsSource = AllPhotos;

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                carousel.Position = (carousel.Position + 1) % AllPhotos.Count;

                return true;
            });
        }

        private async void btnLike_Clicked(object sender, EventArgs e)
        {
            if (userProvider.IsAuthenticated)
            {
                List<LikeViewModel> allUserLikes = await likeService.GetByUser(userProvider.CurrentUser.Id);

                if (allUserLikes.Any(x => x.Room.Id == room.Id))
                {
                    await likeService.Delete(allUserLikes.First(x => x.Room.Id == room.Id).Id);
                }
                else
                {
                    await likeService.Add(new LikeViewModel()
                    {
                        User = userProvider.CurrentUser,
                        Room = room,
                        Date = DateTime.Now,
                    });
                }

                UpdateLikeButtonText();
            }
            else
            {
                await DisplayAlert("Избранное", "Войдите в аккаунт, чтобы воспользоваться этой возможностью", "Ок");
            }
        }

        private void UpdateLikeButtonText()
        {
            if (userProvider.IsAuthenticated)
            {
                List<LikeViewModel> allUserLikes = likeService.GetByUser(userProvider.CurrentUser.Id).Result; // TODO: может не стоит каждый раз читать
                if (allUserLikes.Any())
                    btnLike.Text = "Убрать из избранного";
            }

            btnLike.Text = "В избранное";
        }

    }
}