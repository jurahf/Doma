using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Xamarin.Forms;

namespace Doma
{
    public partial class SearchPage : ContentPage
    {
        private readonly IBookingRemoteService bookingService;
        private readonly ICommodityRemoteService commoditySrvice;

        public SearchPage(IBookingRemoteService bookingService, ICommodityRemoteService commoditySrvice)
        {
            this.bookingService = bookingService;
            this.commoditySrvice = commoditySrvice;

            InitializeComponent();

            LoadData();
        }

        private async Task LoadData()
        {
            List<BookingViewModel> bookings = await bookingService.GetPage();
        }

        private void btnRefresh_Clicked(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
