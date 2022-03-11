using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class SupportRequestConverter : IEntityViewModelConverter<SupportRequestViewModel, SupportRequest>
    {
        public SupportRequest ConvertToStoredModel(SupportRequestViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            return new SupportRequest()
            {
                Id = viewModel.Id,
                DateTime = viewModel.DateTime,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Text = viewModel.Text,
                Theme = viewModel.Theme,
                UserName = viewModel.UserName,
                Status = (StoredModel.Enums.SupportRequestStatus)(int)viewModel.Status,
                User = new User() { Id = viewModel.User?.Id ?? 0, Name = viewModel.User?.Name },
                UserId = viewModel.User?.Id ?? 0,
            };
        }

        public SupportRequestViewModel ConvertToViewModel(SupportRequest dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            return new SupportRequestViewModel()
            {
                Id = dbModel.Id,
                DateTime = dbModel.DateTime,
                Email = dbModel.Email,
                PhoneNumber = dbModel.PhoneNumber,
                Text = dbModel.Text,
                Theme = dbModel.Theme,
                UserName = dbModel.UserName,
                Status = (ViewModel.Enums.SupportRequestStatus)(int)dbModel.Status,
                User = new UserViewModel() { Id = dbModel.User?.Id ?? 0, Name = dbModel.User?.Name },
            };
        }
    }
}
