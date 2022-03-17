using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;
using ViewModel.Enums;

namespace Doma.ControllerParameters
{
    public class ExtendedRoomFilter
    {
        public bool ExistsFreeOnly { get; set; }

        public List<SelectedCommodity> Commodities { get; set; }

        public float? MinPrice { get; set; }

        public float? MaxPrice { get; set; }

        public List<SelectedHotelType> HotelTypes { get; set; }

        public ExtendedRoomFilter()
        {
            Commodities = new List<SelectedCommodity>();
            HotelTypes = new List<SelectedHotelType>();
        }
    }

    public class SelectedCommodity
    {
        public CommodityViewModel Commodity { get; set; }

        public bool Selected { get; set; }
    }

    public class SelectedHotelType
    {
        public HotelType HotelType { get; set; }

        public string Caption { get; set; }

        public bool Selected { get; set; }
    }
}
