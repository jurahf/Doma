using Doma.ControllerParameters;
using Doma.RemoteServices.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices.ServiceDeclarations
{
    public interface IRoomRemoteService : IRemoteService<RoomViewModel>
    {
        Task<List<RoomViewModel>> SearchRooms(SearchRoomFilter filter);
    }
}
