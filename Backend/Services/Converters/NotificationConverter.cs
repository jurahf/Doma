using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class NotificationConverter : IEntityViewModelConverter<NotificationViewModel, Notification>
    {
        public Notification ConvertToStoredModel(NotificationViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            return new Notification()
            {
                Id = viewModel.Id,
                DateTime = viewModel.DateTime,
                Text = viewModel.Text,
                Title = viewModel.Title,
                Status = (StoredModel.Enums.NotificationStatus)(int)viewModel.Status,
                Type = (StoredModel.Enums.NotificationType)(int)viewModel.Type,
                Reciver = new User() { Id = viewModel.Reciver?.Id ?? 0, Name = viewModel.Reciver?.Name },
                UserId = viewModel.Reciver?.Id ?? 0,
            };
        }

        public NotificationViewModel ConvertToViewModel(Notification dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            return new NotificationViewModel()
            {
                Id = dbModel.Id,
                DateTime = dbModel.DateTime,
                Text = dbModel.Text,
                Title = dbModel.Title,
                Status = (ViewModel.Enums.NotificationStatus)(int)dbModel.Status,
                Type = (ViewModel.Enums.NotificationType)(int)dbModel.Type,
                Reciver = new UserViewModel() { Id = dbModel.Reciver?.Id ?? 0, Name = dbModel.Reciver?.Name },
            };
        }
    }
}
