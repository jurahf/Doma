using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class RoomConverter : IEntityViewModelConverter<RoomViewModel, Room>
    {
        private readonly IEntityViewModelConverter<BookingViewModel, Booking> bookingConverter;
        private readonly IEntityViewModelConverter<RoomCategoryViewModel, RoomCategory> categoryConverter;
        private readonly IEntityViewModelConverter<CommodityViewModel, Commodity> commodityConverter;
        private readonly IEntityViewModelConverter<RoomPhotoViewModel, RoomPhoto> photoConverter;
        private readonly IEntityViewModelConverter<LikeViewModel, Like> likeConverter;

        public RoomConverter(
            IEntityViewModelConverter<BookingViewModel, Booking> bookingConverter,
            IEntityViewModelConverter<RoomCategoryViewModel, RoomCategory> categoryConverter,
            IEntityViewModelConverter<CommodityViewModel, Commodity> commodityConverter,
            IEntityViewModelConverter<RoomPhotoViewModel, RoomPhoto> photoConverter,
            IEntityViewModelConverter<LikeViewModel, Like> likeConverter)
        {
            this.bookingConverter = bookingConverter;
            this.categoryConverter = categoryConverter;
            this.commodityConverter = commodityConverter;
            this.photoConverter = photoConverter;
            this.likeConverter = likeConverter;
        }

        public Room ConvertToStoredModel(RoomViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            Room result = new Room()
            {
                Id = viewModel.Id,
                AdultPlaces = viewModel.AdultPlaces,
                Category = withRelations ? categoryConverter.ConvertToStoredModel(viewModel.Category) : null,
                RoomCategoryId = viewModel.Category?.Id ?? 0,
                Bookings = withRelations ? viewModel.Bookings.Select(x => bookingConverter.ConvertToStoredModel(x)).ToList() : new List<Booking>(),
                ChildPlaces = viewModel.ChildPlaces,
                CostPerDay = viewModel.CostPerDay,
                Count = viewModel.Count,
                Description = viewModel.Description,
                Hotel = new Hotel() { Id = viewModel.Hotel?.Id ?? 0, Name = viewModel.Hotel?.Name },
                HotelId = viewModel.Hotel?.Id ?? 0,
                Square = viewModel.Square,
                Photos = withRelations 
                    ? viewModel.Photos.Select(x => photoConverter.ConvertToStoredModel(x)).ToList() 
                    : new List<RoomPhoto>(),
                Likes = withRelations
                    ? viewModel.Likes.Select(x => likeConverter.ConvertToStoredModel(x)).ToList()
                    : new List<Like>(),
            };

            result.Commodities = withRelations
                ? viewModel.Commodities
                .Select(x => new RoomCommodity()
                {
                    Room = result,
                    RoomId = result.Id,
                    Commodity = commodityConverter.ConvertToStoredModel(x),
                    CommodityId = x.Id
                })
                .ToList()
                : new List<RoomCommodity>();

            return result;
        }

        public RoomViewModel ConvertToViewModel(Room dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            RoomViewModel result = new RoomViewModel()
            {
                Id = dbModel.Id,
                AdultPlaces = dbModel.AdultPlaces,
                Category = withRelations ? categoryConverter.ConvertToViewModel(dbModel.Category) : null,
                Bookings = withRelations ? dbModel.Bookings.Select(x => bookingConverter.ConvertToViewModel(x)).ToList() : new List<BookingViewModel>(),
                ChildPlaces = dbModel.ChildPlaces,
                CostPerDay = dbModel.CostPerDay,
                Count = dbModel.Count,
                Description = dbModel.Description,
                Hotel = new HotelViewModel() { Id = dbModel.Hotel?.Id ?? 0, Name = dbModel.Hotel?.Name },
                Square = dbModel.Square,
                Photos = withRelations 
                    ? dbModel.Photos.Select(x => photoConverter.ConvertToViewModel(x)).ToList() 
                    : new List<RoomPhotoViewModel>(),
                Likes = withRelations
                    ? dbModel.Likes.Select(x => likeConverter.ConvertToViewModel(x)).ToList()
                    : new List<LikeViewModel>(),
            };

            result.Commodities = withRelations
                ? dbModel.Commodities
                .Select(x => commodityConverter.ConvertToViewModel(x.Commodity))
                .ToList()
                : new List<CommodityViewModel>();

            return result;
        }
    }
}
