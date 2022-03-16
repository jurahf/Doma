using Doma.ControllerParameters;
using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices.FakeRemoteServices
{
    public class RoomFakeService : IRoomRemoteService
    {
        public Task<int> Add(RoomViewModel value)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RoomViewModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount()
        {
            throw new NotImplementedException();
        }

        public Task<List<RoomViewModel>> GetPage(int page = 0, int limit = 100)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoomViewModel>> SearchRooms(SearchRoomFilter filter)
        {
            List<RoomViewModel> results = Enumerable.Repeat(
                new RoomViewModel()
                {
                    Id = 1,
                    AdultPlaces = 2,
                    ChildPlaces = 0,
                    Category = new RoomCategoryViewModel()
                    {
                        Id = 1,
                        Name = "Обычный номер"
                    },
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
                    Hotel = new HotelViewModel()
                    {
                        Id = 1,
                        City = new CityViewModel() { Id = 129, Name = "Москва", Latitude = 55.748577m, Longitude = 37.637433m },
                        Latitude = 55.748577m,
                        Longitude = 37.637433m,
                        Address = "Москворецкая наб., 7с2, Москва, 109240",
                        Name = "VOYAGE Hotel & Hostel",
                        Stars = 2,
                        Type = ViewModel.Enums.HotelType.Hostel
                    },
                    Commodities = new List<CommodityViewModel>()
                    {
                        new CommodityViewModel() { Id = 3, Name = "Wi-Fi" },
                        new CommodityViewModel() { Id = 4, Name = "Телевизор" },
                        new CommodityViewModel() { Id = 8, Name = "Односпальные кровати" },
                    },
                    Bookings = new List<BookingViewModel>()
                    {
                    }
                }
                , 10)
                .ToList();

            return results;
        }

        public Task Update(int id, RoomViewModel value)
        {
            throw new NotImplementedException();
        }
    }
}
