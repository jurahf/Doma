using Services.Converters;
using Services.Parameters;
using Services.RepositoryDeclaration;
using Services.ServiceDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
    public class RoomService : BaseEntityService<RoomViewModel, Room>, IRoomService
    {
        private readonly IRoomRepository repository;

        public RoomService(
            IRoomRepository repository,
            IEntityViewModelConverter<RoomViewModel, Room> converter)
            : base(repository, converter)
        {
            this.repository = repository;
        }

        public async Task<List<RoomViewModel>> SearchRooms(SearchRoomsFilter filter)
        {
            List<Room> rooms = await repository.SearchRooms(filter);
            return rooms.Select(x => converter.ConvertToViewModel(x)).ToList();
        }
    }
}