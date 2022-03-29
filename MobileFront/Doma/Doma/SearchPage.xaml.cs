using Doma.Authorization;
using Doma.ControllerParameters;
using Doma.RemoteServices.Common;
using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
        private readonly ICityRemoteService cityService;
        private readonly IRoomRemoteService roomService;
        private readonly IHotelRemoteService hotelService;
        private readonly ILikeRemoteService likeService;
        private readonly ICurrentUserProvider userProvider;

        private CityViewModel selectedCity = null;
        private List<CityViewModel> cityAutocompleteData = new List<CityViewModel>();
        private DateTime? startDate;
        private DateTime? endDate;
        private int adultsCount;
        private int childrenCount;

        public SearchPage(
            IRoomRemoteService roomService,
            ICityRemoteService cityService,
            IHotelRemoteService hotelService,
            ILikeRemoteService likeService,
            ICurrentUserProvider userProvider)
        {
            this.roomService = roomService;
            this.cityService = cityService;
            this.hotelService = hotelService;
            this.likeService = likeService;
            this.userProvider = userProvider;

            InitializeComponent();

            cldDates.Culture = GlobalSettings.DefaultCulture;
            cldDates.MinimumDate = DateTime.Today;

            LoadData();
        }


        #region city autocomplete

        private void City_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshCitySuggestion(e.NewTextValue);
        }

        private void RefreshCitySuggestion(string newTextValue)
        {
            if (string.IsNullOrWhiteSpace(newTextValue))
            {
                cityListView.IsVisible = false;
                selectedCity = null;
                return;
            }

            cityListView.IsVisible = true;
            cityListView.BeginRefresh();

            string text = newTextValue.ToLower();
            var data = cityAutocompleteData
                .Where(i => i.Name.ToLower()
                    .Contains(text));

            if (!data.Any())
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
            btnCityUnexpand.IsVisible = false;
            tbCityName.HorizontalTextAlignment = TextAlignment.Center;
        }

        #endregion


        public DateTime? SelectedStartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                tbDates.Text = $"С {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}";
                OnPropertyChanged(nameof(SelectedStartDate));
            }
        }

        public DateTime? SelectedEndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                tbDates.Text = $"С {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}";
                OnPropertyChanged(nameof(SelectedEndDate));
            }
        }

        public int AdultsCount
        {
            get
            {
                return adultsCount;
            }
            set
            {
                adultsCount = value;
                tbPersons.Text = $"{adultsCount} взрослых, {childrenCount} детей";
                OnPropertyChanged(nameof(AdultsCount));
            }
        }

        public int ChildrenCount
        {
            get
            {
                return childrenCount;
            }
            set
            {
                childrenCount = value;
                tbPersons.Text = $"{adultsCount} взрослых, {childrenCount} детей";
                OnPropertyChanged(nameof(ChildrenCount));
            }
        }



        private async Task LoadData()
        {
            try
            {
                SelectedStartDate = DateTime.Now;
                SelectedEndDate = DateTime.Now.AddDays(1);
                AdultsCount = 1;

                cityAutocompleteData = await cityService.GetPage(0, 1000);
                //List<BookingViewModel> bookings = await bookingService.GetPage();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Ошибка при загрузке данных. Проверьте ваше подключение к сети.", "Закрыть");

            }
        }

        private void tbCityName_Focused(object sender, FocusEventArgs e)
        {
            ExpandFrame(frmCity, inCityFrameLayout);
            btnCityUnexpand.IsVisible = true;
            tbCityName.HorizontalTextAlignment = TextAlignment.Start;
            RefreshCitySuggestion(tbCityName.Text);
        }

        private void btnCityUnexpand_Clicked(object sender, EventArgs e)
        {
            CollapseFrame(frmCity, inCityFrameLayout);
            btnCityUnexpand.IsVisible = false;
            tbCityName.HorizontalTextAlignment = TextAlignment.Center;
        }

        private void tbDatesName_Focused(object sender, FocusEventArgs e)
        {
            ExpandFrame(frmDates, inDatesFrameLayout);
            btnDatesUnexpand.IsVisible = true;
            tbDates.IsReadOnly = true;
            tbDates.HorizontalOptions = LayoutOptions.StartAndExpand;
        }

        private void btnDatesUnexpand_Clicked(object sender, EventArgs e)
        {
            CollapseFrame(frmDates, inDatesFrameLayout);
            btnDatesUnexpand.IsVisible = false;
            tbDates.IsReadOnly = false;
            tbDates.HorizontalOptions = LayoutOptions.CenterAndExpand;
        }

        private void tbPersonsName_Focused(object sender, FocusEventArgs e)
        {
            ExpandFrame(frmPersons, inPersonsFrameLayout);
            btnPersonsUnexpand.IsVisible = true;
            tbPersons.IsReadOnly = true;
            tbPersons.HorizontalOptions = LayoutOptions.StartAndExpand;
        }

        private void btnPersonsUnexpand_Clicked(object sender, EventArgs e)
        {
            CollapseFrame(frmPersons, inPersonsFrameLayout);
            btnPersonsUnexpand.IsVisible = false;
            tbPersons.IsReadOnly = false;
            tbPersons.HorizontalOptions = LayoutOptions.CenterAndExpand;
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

        private async void btnSearch_Clicked(object sender, EventArgs e)
        {
            SearchRoomFilter filter = new SearchRoomFilter()
            {
                CityId = selectedCity?.Id,
                StartDate = SelectedStartDate,
                EndDate = SelectedEndDate,
                AdultsCount = AdultsCount,
                ChildrenCount = ChildrenCount
            };

            List<RoomViewModel> results = await roomService.SearchRooms(filter);
            await this.Navigation.PushAsync(new SearchResultListPage(results, filter, hotelService, likeService, userProvider));
        }
    }
}
