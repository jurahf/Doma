using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices.FakeRemoteServices
{
    public class HotelFakeService : IHotelRemoteService
    {
        public Task<int> Add(HotelViewModel value)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<HotelViewModel> Get(int id)
        {
            return new HotelViewModel()
            {
                Id = id,
                City = new CityViewModel() { Id = 129, Name = "Москва", Latitude = 55.748577m, Longitude = 37.637433m },
                Latitude = 55.748577m,
                Longitude = 37.637433m,
                Address = "Москворецкая наб., 7с2, Москва, 109240",
                Name = "VOYAGE Hotel & Hostel",
                Stars = 2,
                Type = ViewModel.Enums.HotelType.Hostel
            };

            /*
                .Include(x => x.Feedbacks)
                .Include(x => x.Employees)
                    .ThenInclude(x => x.User)
                .Include(x => x.HotelOptions)
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.Bookings)
                .Include(x => x.City);
            */
        }

        public Task<int> GetCount()
        {
            throw new NotImplementedException();
        }

        public Task<List<HotelViewModel>> GetPage(int page = 0, int limit = 100)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, HotelViewModel value)
        {
            throw new NotImplementedException();
        }
    }
}
