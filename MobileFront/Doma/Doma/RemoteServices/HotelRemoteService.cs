using Doma.Authorization;
using Doma.RemoteServices.Common;
using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Doma.RemoteServices
{
    public class HotelRemoteService : BaseRemoteService<HotelViewModel>, IHotelRemoteService
    {
        protected override string ControllerPath => "api/hotel";

        public HotelRemoteService(IRequestProvider requestProvider, ICurrentUserProvider userProvider)
            : base(requestProvider, userProvider)
        {
        }
    }
}
