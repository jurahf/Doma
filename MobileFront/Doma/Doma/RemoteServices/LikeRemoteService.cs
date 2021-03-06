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
    public class LikeRemoteService : BaseRemoteService<LikeViewModel>, ILikeRemoteService
    {
        protected override string ControllerPath => "api/like";


        public LikeRemoteService(IRequestProvider requestProvider, ICurrentUserProvider userProvider)
            : base(requestProvider, userProvider)
        {
        }


        public async Task<List<LikeViewModel>> GetByRoom(int roomId)
        {
            return await requestProvider.GetAsync<List<LikeViewModel>>(
                $"{backendUri}/{ControllerPath}/GetByRoom?roomId={roomId}",
                userProvider.Token);
        }

        public async Task<List<LikeViewModel>> GetByUser(int userId)
        {
            return await requestProvider.GetAsync<List<LikeViewModel>>(
                $"{backendUri}/{ControllerPath}/GetByUser?userId={userId}",
                userProvider.Token);
        }
    }
}
