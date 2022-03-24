using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class LikeConverter : IEntityViewModelConverter<LikeViewModel, Like>
    {
        public Like ConvertToStoredModel(LikeViewModel viewModel, bool withRelations = true)
        {
            return new Like()
            {
                Id = viewModel.Id,
                Date = viewModel.Date,
                User = new User() { Id = viewModel.User?.Id ?? 0, Name = viewModel.User?.Name },
                UserId = viewModel.User?.Id ?? 0,
                Hotel = new Hotel() { Id = viewModel.Hotel?.Id ?? 0, Name = viewModel.Hotel?.Name },
                HotelId = viewModel.Hotel?.Id ?? 0
            };
        }

        public LikeViewModel ConvertToViewModel(Like dbModel, bool withRelations = true)
        {
            return new LikeViewModel()
            {
                Id = dbModel.Id,
                Date = dbModel.Date,
                User = new UserViewModel() { Id = dbModel.User?.Id ?? 0, Name = dbModel.User?.Name },
                Hotel = new HotelViewModel() { Id = dbModel.Hotel?.Id ?? 0, Name = dbModel.Hotel?.Name },
            };
        }
    }
}
