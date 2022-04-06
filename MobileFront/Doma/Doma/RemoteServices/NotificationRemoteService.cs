using Doma.Authorization;
using Doma.ControllerParameters;
using Doma.RemoteServices.Common;
using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices
{
    public class NotificationRemoteService : BaseRemoteService<NotificationViewModel>, INotificationRemoteService
    {
        protected override string ControllerPath => "api/notification";

        public NotificationRemoteService(IRequestProvider requestProvider, ICurrentUserProvider userProvider)
            : base(requestProvider, userProvider)
        {
        }

        public async Task CreateNewBookingEvent(int bookingId)
        {
            string uri = $"{backendUri}/{ControllerPath}/CreateNewBookingEvent";

            CreateNewBookingEventRequest data = new CreateNewBookingEventRequest()
            {
                BookingId = bookingId
            };

            await requestProvider.PostAsync<bool>(uri, data, userProvider.Token);
        }
    }
}
