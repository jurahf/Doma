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
    public class CityRemoteService : BaseRemoteService<CityViewModel>, ICityRemoteService
    {
        protected override string ControllerPath => "api/city";


        public CityRemoteService(IRequestProvider requestProvider, ICurrentUserProvider userProvider)
            : base(requestProvider, userProvider)
        {
        }

        public override async Task<List<CityViewModel>> GetPage(int page = 0, int limit = 100)
        {
            return await base.GetPage(page, 1000);
        }
    }
}
