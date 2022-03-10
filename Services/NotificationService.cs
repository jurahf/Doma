using Services.Converters;
using Services.RepositoryDeclaration;
using Services.ServiceDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services
{
    public class NotificationService : BaseEntityService<NotificationViewModel, Notification>, INotificationService
    {
        public NotificationService(
            INotificationRepository repository,
            IEntityViewModelConverter<NotificationViewModel, Notification> converter)
            : base(repository, converter)
        {
        }
    }
}