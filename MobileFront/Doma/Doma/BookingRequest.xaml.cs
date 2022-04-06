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
    public partial class BookingRequest : BaseViewWithAuth
    {
        private readonly IBookingRemoteService bookingService;
        private readonly INotificationRemoteService notificationService;


        public BookingViewModel Booking { get; set; }


        public BookingRequest(
            ICurrentUserProvider userProvider,
            IBookingRemoteService bookingService,
            INotificationRemoteService notificationService,
            BookingViewModel booking)
            : base(userProvider)
        {
            this.bookingService = bookingService;
            this.notificationService = notificationService;
            this.Booking = booking;

            InitializeComponent();
        }

        protected override void ShowFilledView()
        {
            mainContent.IsVisible = true;

            Booking.Client = userProvider.CurrentUser; // потому что могли авторизоваться только сейчас
        }

        protected override void ShowNotAuthView()
        {
            mainContent.IsVisible = false;
        }

        public async void btnConfirm_Clicked(object sender, EventArgs args)
        {
            try
            {
                int bookingId = await bookingService.Add(Booking);

                await notificationService.CreateNewBookingEvent(bookingId);

                await DisplayAlert("Бронирование создано!", "Дождитесь, пока отель подтвердит заявку, или свяжитесь с отелем через чат.", "ОК");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Произошла неизвестная ошибка. Пожалуйста, повторите действия позже", "ОК");
            }
        }

        public async void btnReject_Clicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

    }
}