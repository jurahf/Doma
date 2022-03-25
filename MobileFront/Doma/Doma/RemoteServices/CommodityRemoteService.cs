using Doma.Authorization;
using Doma.RemoteServices.Common;
using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Doma.RemoteServices
{
    public class CommodityRemoteService : BaseRemoteService<CommodityViewModel>, ICommodityRemoteService
    {
        protected override string ControllerPath => "api/commodity";

        public CommodityRemoteService(IRequestProvider requestProvider, ICurrentUserProvider userProvider)
            : base(requestProvider, userProvider)
        {
        }
    }
}
