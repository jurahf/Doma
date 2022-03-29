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

        private string likeButtonTitle;
        public string LikeButtonTitle 
        {
            get
            {
                return likeButtonTitle;
            }
            set
            {
                if (likeButtonTitle == value)
                    return;

                likeButtonTitle = value;
                OnPropertyChanged(nameof(LikeButtonTitle));
            } 
        }

        private bool inited = false;

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
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!inited)
            {
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

            await UpdateLikeButtonText();

            inited = true;
        }

        private async void btnLike_Clicked(object sender, EventArgs e)
        {
            if (await userProvider.IsAuthenticated())
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

                await UpdateLikeButtonText();
            }
            else
            {
                await DisplayAlert("Избранное", "Войдите в аккаунт, чтобы воспользоваться этой возможностью", "Ок");
            }
        }

        private async Task UpdateLikeButtonText()
        {
            LikeButtonTitle = "В избранное";

            if (await userProvider.IsAuthenticated())
            {
                List<LikeViewModel> allUserLikes = await likeService.GetByUser(userProvider.CurrentUser.Id); // TODO: может не стоит каждый раз читать
                if (allUserLikes.Any())
                    LikeButtonTitle = "Убрать из избранного";
            }
        }

    }
}