using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services.ServiceDeclaration
{
    public interface INotificationService : IEntityService<NotificationViewModel>
    {
        Task CreateNewBookingEvent(int bookingId, int initorUserId);
    }
}
