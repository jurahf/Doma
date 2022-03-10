using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class FeedbackConverter : IEntityViewModelConverter<FeedbackViewModel, Feedback>
    {
        public Feedback ConvertToStoredModel(FeedbackViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            return new Feedback()
            {
                Id = viewModel.Id,
                DateTime = viewModel.DateTime,
                Estimate = viewModel.Estimate,
                Text = viewModel.Text,
                Booking = new Booking() { Id = viewModel.Booking?.Id ?? 0 },
                BookingId = viewModel.Booking?.Id ?? 0,
                Hotel = new Hotel() { Id = viewModel.Hotel?.Id ?? 0, Name = viewModel.Hotel?.Name },
                HotelId = viewModel.Hotel?.Id ?? 0,
            };
        }

        public FeedbackViewModel ConvertToViewModel(Feedback dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            return new FeedbackViewModel()
            {
                Id = dbModel.Id,
                DateTime = dbModel.DateTime,
                Estimate = dbModel.Estimate,
                Text = dbModel.Text,
                Booking = new BookingViewModel() { Id = dbModel.Booking?.Id ?? 0 },
                Hotel = new HotelViewModel() { Id = dbModel.Hotel?.Id ?? 0, Name = dbModel.Hotel?.Name },
            };
        }
    }
}
