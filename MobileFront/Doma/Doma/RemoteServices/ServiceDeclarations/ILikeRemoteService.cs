using Doma.RemoteServices.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices.ServiceDeclarations
{
    public interface ILikeRemoteService : IRemoteService<LikeViewModel>
    {
        Task<List<LikeViewModel>> GetByRoom(int roomId);

        Task<List<LikeViewModel>> GetByUser(int userId);
    }
}
