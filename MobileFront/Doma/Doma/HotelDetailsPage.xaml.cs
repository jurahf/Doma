using Doma.Authorization;
using Doma.ControllerParameters;
using Doma.RemoteServices.ServiceDeclarations;
using Doma.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Enums;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Doma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HotelDetailsPage : ContentPage
    {
        private readonly ILikeRemoteService likeService;
        private readonly IBookingRemoteService bookingService;
        private readonly INotificationRemoteService notificationService;
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
            IBookingRemoteService bookingService,
            INotificationRemoteService notificationService,
            ICurrentUserProvider userProvider)
        {
            SetParamsToRoom(filter, room);
            foreach (var r in hotel.Rooms)
                SetParamsToRoom(filter, r);

            this.hotel = hotel;
            this.room = room;
            this.likeService = likeService;
            this.bookingService = bookingService;
            this.notificationService = notificationService;
            this.userProvider = userProvider;

            InitializeComponent();
        }

        private void SetParamsToRoom(SearchRoomFilter filter, RoomViewModel room)
        {
            room.BookingStartDate = filter?.StartDate;
            room.BookingEndDate = filter?.EndDate;
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // одна из кнопок "забронировать"

            Button button = (sender as Button);
            int id = int.Parse(TagAttProp.GetTag(button));

            room = hotel.Rooms.FirstOrDefault(x => x.Id == id);


            BookingViewModel bookingProj = new BookingViewModel()
            {
                Client = userProvider.CurrentUser,
                //ComingTime
                StartDate = room.BookingStartDate ?? DateTime.Now,
                EndDate = room.BookingEndDate ?? DateTime.Now.AddDays(1),
                Room = room, 
                Status = BookingStatus.Request,
            };

            await Navigation.PushAsync(
                    new BookingRequest(
                        userProvider,
                        bookingService,
                        notificationService,
                        bookingProj));
        }
    }


    public class TagAttProp
    {
        public static readonly BindableProperty TagProperty =
          BindableProperty.CreateAttached("Tag", typeof(string), typeof(TagAttProp), "");

        public static string GetTag(BindableObject view)
        {
            return (string)view.GetValue(TagProperty);
        }

        public static void SetTag(BindableObject view, string value)
        {
            view.SetValue(TagProperty, value);
        }
    }


}