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
        private readonly ICurrentUserProvider userProvider;


        public LikeRemoteService(IRequestProvider requestProvider, ICurrentUserProvider userProvider)
            : base(requestProvider)
        {
            this.userProvider = userProvider;
        }


        public async Task<List<LikeViewModel>> GetByHotel(int hotelId)
        {
            return await requestProvider.GetAsync<List<LikeViewModel>>(
                $"{backendUri}/{ControllerPath}/GetByHotel?hotelId={hotelId}",
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
