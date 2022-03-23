using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices.FakeRemoteServices
{
    public class CityFakeService : ICityRemoteService
    {
        public Task<int> Add(CityViewModel value)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CityViewModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CityViewModel>> GetPage(int page = 0, int limit = 100)
        {
            return new List<CityViewModel>()
            {
                new CityViewModel() { Id = 129, Name = "Москва" },
                new CityViewModel() { Id = 74, Name = "Санкт-Петербург" },
                new CityViewModel() { Id = 3, Name = "Московская область" },
                new CityViewModel() { Id = 75, Name = "Самара" },
                new CityViewModel() { Id = 71, Name = "Саратов" },
            };
        }

        public Task Update(int id, CityViewModel value)
        {
            throw new NotImplementedException();
        }
    }
}
