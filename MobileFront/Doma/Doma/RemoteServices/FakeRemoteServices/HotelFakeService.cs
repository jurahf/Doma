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
                Type = ViewModel.Enums.HotelType.Hostel,
                Rooms = new List<RoomViewModel>()
                {
                    new RoomViewModel()
                    {
                        Id = 1,
                        AdultPlaces = 2,
                        ChildPlaces = 0,
                        CostPerDay = 2890.0f,
                        Count = 2,
                        Description = @"Этот простой хостел находится в 12 минутах ходьбы от станции метро ""Китай - город"", в 6 минутах ходьбы от сталинской высотки на Котельнической набережной и в 3 км от дворцов и музеев знаменитого Московского Кремля.
    Общие номера, оформленные в ярких тонах, оборудованы доступом к Wi - Fi, двухъярусными кроватями с занавесками и лампами для чтения.Есть общие ванные комнаты.В отдельных номерах установлены телевизоры с плоским экраном.В них могут разместиться до 2 человек. Имеется также семейный номер.
    В распоряжении гостей общая кухня,обеденная зона и услуги прачечной.",
                        Square = 20,
                        Photos = new List<RoomPhotoViewModel>()
                        {
                            new RoomPhotoViewModel() { Id = 1, Title = "Обычный номер", Url = "https://hotelier.pro/upload/iblock/868/8687bfc0f0898e8e4074d44166df587c.jpg" },
                            new RoomPhotoViewModel() { Id = 2, Title = "Обычный номер",     Url = "https://m.buro247.ru/images/tanechka/lego1_17_13x021_1.JPG" },
                            new RoomPhotoViewModel() { Id = 3, Title = "Стандартный номер", Url = "https://kitchen.cdnvideo.ru/wp-content/uploads/2019/10/tajtl-2.jpg" },
                            new RoomPhotoViewModel() { Id = 4, Title = "Номер люкс",        Url = "https://blog.ostrovok.ru/wp-content/uploads/2012/02/download.jpg" },
                            new RoomPhotoViewModel() { Id = 5, Title = "Номер люкс",        Url = "http://hotelmaster.ru/wp-content/uploads/2016/02/room-service-discontinued-1024x693-460x260" },
                        },
                        Bookings = new List<BookingViewModel>()
                        {
                        }
                    }
                }
            };

            /*
                .Include(x => x.Feedbacks)
                .Include(x => x.Employees)
                    .ThenInclude(x => x.User)
                .Include(x => x.HotelOptions)
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.Bookings)
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.Photos)
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
