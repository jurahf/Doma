using Doma.ControllerParameters;
using Doma.RemoteServices.Common;
using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices
{
    public class RoomRemoteService : BaseRemoteService<RoomViewModel>, IRoomRemoteService
    {
        protected override string ControllerPath => "api/room";

        public RoomRemoteService(IRequestProvider requestProvider)
            : base(requestProvider)
        {
        }

        public async Task<List<RoomViewModel>> SearchRooms(SearchRoomFilter filter)
        {
            string uri = $"{backendUri}/{ControllerPath}/SearchRooms";

            return await requestProvider.PostAsync<List<RoomViewModel>>(uri, filter, ""); // искать можно и без токена авторизации
        }
    }
}
