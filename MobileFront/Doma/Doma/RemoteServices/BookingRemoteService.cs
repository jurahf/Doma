using Doma.Authorization;
using Doma.RemoteServices.Common;
using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices
{
    public class BookingRemoteService : BaseRemoteService<BookingViewModel>, IBookingRemoteService
    {
        protected override string ControllerPath => "api/booking";


        public BookingRemoteService(IRequestProvider requestProvider, ICurrentUserProvider userProvider)
            : base(requestProvider, userProvider)
        {
        }
    }
}
