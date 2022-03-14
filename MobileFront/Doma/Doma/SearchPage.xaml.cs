using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Doma
{
    public partial class SearchPage : ContentPage
    {
        private readonly IBookingRemoteService bookingService;
        private readonly ICommodityRemoteService commoditySrvice;
        private readonly ICityRemoteService cityService;

        public SearchPage(
            IBookingRemoteService bookingService, 
            ICommodityRemoteService commoditySrvice,
            ICityRemoteService cityService)
        {
            this.bookingService = bookingService;
            this.commoditySrvice = commoditySrvice;
            this.cityService = cityService;

            InitializeComponent();

            dtpStartDate.MinimumDate = DateTime.Now;

            LoadData();
        }


        #region city autocomplete

        private CityViewModel selectedCity = null;
        private List<CityViewModel> cityAutocompleteData = new List<CityViewModel>();

        private void City_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            cityListView.IsVisible = true;
            cityListView.BeginRefresh();

            string text = e.NewTextValue.ToLower();
            var data = cityAutocompleteData
                .Where(i => i.Name.ToLower()
                    .Contains(text));

            if (string.IsNullOrWhiteSpace(e.NewTextValue) || !data.Any())
            {
                cityListView.IsVisible = false;
                selectedCity = null;
            }
            else
            {
                cityListView.ItemsSource = data;
            }

            cityListView.EndRefresh();
        }

        private void ListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            selectedCity = e.Item as CityViewModel;
            tbCityName.Text = selectedCity?.Name;
            cityListView.IsVisible = false;

            ((ListView)sender).SelectedItem = null;

            CollapseFrame(frmCity, inCityFrameLayout);
        }

        #endregion


        private async Task LoadData()
        {
            try
            {
                cityAutocompleteData = await cityService.GetPage(0, 1000);
                //List<BookingViewModel> bookings = await bookingService.GetPage();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Ошибка при загрузке данных", "Закрыть");
            }
        }

        private void btnRefresh_Clicked(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tbCityName_Focused(object sender, FocusEventArgs e)
        {
            ExpandFrame(frmCity, inCityFrameLayout);
            btnCityUnexpand.IsVisible = true;
            tbCityName.HorizontalTextAlignment = TextAlignment.Start;
        }

        private void btnCityUnexpand_Clicked(object sender, EventArgs e)
        {
            CollapseFrame(frmCity, inCityFrameLayout);
            btnCityUnexpand.IsVisible = false;
            tbCityName.HorizontalTextAlignment = TextAlignment.Center;
        }

        private void ExpandFrame(Frame frame, Layout layout)
        {
            Animation animation = new Animation((d) =>
            {
                frame.Margin = new Thickness(0, 20);
                frame.HeightRequest = GetScreenHeight();
                frame.MinimumHeightRequest = GetScreenHeight();
                frame.CornerRadius = 24;

                layout.HorizontalOptions = LayoutOptions.Start;
                layout.VerticalOptions = LayoutOptions.Start;
            }, 
            48,
            GetScreenHeight());

            animation.Commit(frame, "Expand frame");
        }

        private void CollapseFrame(Frame frame, Layout layout)
        {
            Animation animation = new Animation((d) =>
            {
                frame.Margin = new Thickness(20, 20);
                frame.MinimumHeightRequest = d;
                frame.HeightRequest = d;
                frame.CornerRadius = 100;

                layout.HorizontalOptions = LayoutOptions.Center;
                layout.VerticalOptions = LayoutOptions.Center;
            },
            GetScreenHeight(),
            48);

            animation.Commit(frame, "Collapse frame");
        }

        private double GetScreenHeight()
        {
            return Application.Current?.MainPage?.Height
                ?? (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);
        }

    }
}
