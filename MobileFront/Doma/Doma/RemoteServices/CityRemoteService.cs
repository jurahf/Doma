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


        public CityRemoteService(IRequestProvider requestProvider)
            : base(requestProvider)
        {
        }

        public override async Task<List<CityViewModel>> GetPage(int page = 0, int limit = 100)
        {
#if DEBUG
            return new List<CityViewModel>()
            {
                new CityViewModel() { Id = 1, Name = "Moskow" },
                new CityViewModel() { Id = 2, Name = "Sankt-Peterburg" },
                new CityViewModel() { Id = 3, Name = "Moskow region" },
                new CityViewModel() { Id = 4, Name = "Samara" },
                new CityViewModel() { Id = 5, Name = "Saratov" },
            };
#else
            return await base.GetPage(page, 1000);
#endif
        }
    }
}
