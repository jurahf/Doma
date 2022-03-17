using Doma.ControllerParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit;
using ViewModel;

namespace Doma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultFilterPage : ContentPage
    {
        public ExtendedRoomFilter Filter { get; set; }


        public SearchResultFilterPage(ExtendedRoomFilter filter, List<RoomViewModel> allList)
        {
            this.Filter = filter;

            InitializeComponent();

            commodityListView.ItemsSource = Filter.Commodities.OrderBy(x => x.Commodity.Name).ToList();

            float minPrice = allList.Min(x => x.CostPerDay);
            float maxPrice = allList.Max(x => x.CostPerDay);
            priceSlider.MinimumValue = minPrice;
            priceSlider.MaximumValue = minPrice == maxPrice ? maxPrice + 1000 : maxPrice;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void commodityListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            commodityListView.SelectedItem = null;
        }

        private void hotelTypeListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            hotelTypeListView.SelectedItem = null;
        }
    }
}