using Doma.Authorization;
using Doma.ControllerParameters;
using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Enums;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Doma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultListPage : ContentPage
    {
        private readonly IHotelRemoteService hotelService;
        private readonly ILikeRemoteService likeService;
        private readonly IBookingRemoteService bookingService;
        private readonly ICurrentUserProvider userProvider;
        private readonly INotificationRemoteService notificationService;
        private SearchRoomFilter baseFilter;

        public List<RoomViewModel> SearchList { get; set; }
        public List<RoomViewModel> FilteredSearchList { get; set; }
        public ExtendedRoomFilter extendedFilter { get; set; }


        public int Days
        {
            get { return (baseFilter.EndDate - baseFilter.StartDate)?.Days ?? 1; }
        }



        public SearchResultListPage(
            List<RoomViewModel> searchList, 
            SearchRoomFilter baseFilter,
            IHotelRemoteService hotelService,
            ILikeRemoteService likeService,
            IBookingRemoteService bookingService,
            INotificationRemoteService notificationService,
            ICurrentUserProvider userProvider)
        {
            InitializeComponent();

            foreach (var room in searchList)
                SetParamsToRoom(baseFilter, room);

            this.SearchList = searchList;   // TODO: группировать по отелям
            this.baseFilter = baseFilter;
            this.hotelService = hotelService;
            this.likeService = likeService;
            this.bookingService = bookingService;
            this.notificationService = notificationService;
            this.userProvider = userProvider;

            extendedFilter = new ExtendedRoomFilter() 
            {
                ExistsFreeOnly = true,
                MinPrice = searchList.Min(x => x.CostPerDay),
                MaxPrice = searchList.Max(x => x.CostPerDay),
                Commodities = searchList.SelectMany(x => x.Commodities)
                        .Distinct(new IdEqualityComparer())
                        .OfType<CommodityViewModel>()
                        .Select(x => new SelectedCommodity()
                        {
                            Commodity = x,
                            Selected = false
                        })
                        .ToList(),
                HotelTypes = new List<SelectedHotelType>()
                {
                    new SelectedHotelType() { HotelType = HotelType.Hotel, Selected = true, Caption = "Гостиница" },
                    new SelectedHotelType() { HotelType = HotelType.Apartments, Selected = true, Caption = "Апартаменты" },
                    new SelectedHotelType() { HotelType = HotelType.House, Selected = true, Caption = "Дом" },
                    new SelectedHotelType() { HotelType = HotelType.Camping, Selected = true, Caption = "Кемпинг" },
                    new SelectedHotelType() { HotelType = HotelType.Hostel, Selected = true, Caption = "Хостел" },
                }
            };
            ApplyFilter(SearchList, extendedFilter);
        }

        private void SetParamsToRoom(SearchRoomFilter filter, RoomViewModel room)
        {
            room.BookingStartDate = filter.StartDate;
            room.BookingEndDate = filter.EndDate;
        }


        private void ApplyFilter(List<RoomViewModel> searchList, ExtendedRoomFilter extendedFilter)
        {
            IEnumerable<RoomViewModel> result = new List<RoomViewModel>(searchList);

            if (extendedFilter.ExistsFreeOnly)
            {
                result = result.Where(x => x.FreeCount(baseFilter.StartDate, baseFilter.EndDate) > 0);
            }

            if (extendedFilter.MinPrice != null)
            {
                result = result.Where(x => x.CostPerDay >= extendedFilter.MinPrice.Value);
            }

            if (extendedFilter.MaxPrice != null)
            {
                result = result.Where(x => x.CostPerDay <= extendedFilter.MaxPrice.Value);
            }

            var selectedTypes = extendedFilter.HotelTypes
                .Where(x => x.Selected)
                .Select(x => x.HotelType);
            if (selectedTypes.Any())
            {
                result = result.Where(r => selectedTypes.Any(f => f == r.Hotel.Type));
            }

            var selectedComm = extendedFilter.Commodities
                .Where(x => x.Selected)
                .Select(x => x.Commodity);
            if (selectedComm.Any())
            {
                result = result
                    .Where(r => selectedComm.All(f => r.Commodities.Any(rc => rc.Id == f.Id)));
            }

            FilteredSearchList = result.ToList();
            MyListView.ItemsSource = FilteredSearchList;
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            MyListView.SelectedItem = null;

            RoomViewModel room = e.Item as RoomViewModel;
            HotelViewModel hotel = await hotelService.Get(room.Hotel.Id);

            await Navigation.PushAsync(new HotelDetailsPage(hotel, room, baseFilter, likeService, bookingService, notificationService, userProvider));
        }

        private async void Filter_Clicked(object sender, EventArgs e)
        {
            var filterPage = new SearchResultFilterPage(extendedFilter, SearchList);
            filterPage.Disappearing += (s, a) =>
            {
                extendedFilter = filterPage.Filter;
                ApplyFilter(SearchList, extendedFilter);
            };

            await Navigation.PushModalAsync(filterPage);
        }

    }
}
