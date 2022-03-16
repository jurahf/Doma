using Services.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services.ServiceDeclaration
{
    public interface IRoomService : IEntityService<RoomViewModel>
    {
        Task<List<RoomViewModel>> SearchRooms(SearchRoomsFilter filter);
    }
}
