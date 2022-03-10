using StoredModel;
using StoredModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class BookingConverter : IEntityViewModelConverter<BookingViewModel, Booking>
    {
        private readonly IEntityViewModelConverter<FeedbackViewModel, Feedback> feedbackConverter;
        private readonly IEntityViewModelConverter<HotelOptionViewModel, HotelOption> hotelOptionConverter;

        public BookingConverter(
            IEntityViewModelConverter<FeedbackViewModel, Feedback> feedbackConverter,
            IEntityViewModelConverter<HotelOptionViewModel, HotelOption> hotelOptionConverter)
        {
            this.feedbackConverter = feedbackConverter;
            this.hotelOptionConverter = hotelOptionConverter;
        }

        public Booking ConvertToStoredModel(BookingViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            Booking result = new Booking()
            {
                Id = viewModel.Id,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                ComingTime = viewModel.ComingTime,
                Status = (StoredModel.Enums.BookingStatus)(int)viewModel.Status,
                Client = new User() { Id = viewModel.Client?.Id ?? 0, Name = viewModel.Client?.Name },
                UserId = viewModel.Client?.Id ?? 0,
                Feedback = withRelations ? feedbackConverter.ConvertToStoredModel(viewModel.Feedback) : null,
                Room = new Room() { Id = viewModel.Room?.Id ?? 0 },
                RoomId = viewModel.Room?.Id ?? 0,
            };

            result.Options = withRelations
                ? viewModel.Options?
                    .Select(x => new BookingHotelOption()
                    {
                        HotelOption = hotelOptionConverter.ConvertToStoredModel(x),
                        HotelOptionId = x.Id,
                        Booking = result,
                        BookingId = result.Id,
                    })
                    .ToList()
                : new List<BookingHotelOption>();

            return result;
        }

        public BookingViewModel ConvertToViewModel(Booking dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            BookingViewModel result = new BookingViewModel()
            {
                Id = dbModel.Id,
                StartDate = dbModel.StartDate,
                EndDate = dbModel.EndDate,
                ComingTime = dbModel.ComingTime,
                Status = (ViewModel.Enums.BookingStatus)(int)dbModel.Status,
                Feedback = withRelations ? feedbackConverter.ConvertToViewModel(dbModel.Feedback) : null,
                Client = new UserViewModel() { Id = dbModel.Client?.Id ?? 0, Name = dbModel.Client?.Name },
                Room = new RoomViewModel() { Id = dbModel.Room?.Id ?? 0, Description = dbModel.Room?.Description ?? "" },
            };

            result.Options = withRelations
                ? dbModel.Options?
                    .Select(x => hotelOptionConverter.ConvertToViewModel(x?.HotelOption))
                    .ToList()
                : new List<HotelOptionViewModel>();

            return result;
        }
    }
}
