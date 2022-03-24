using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services.ServiceDeclaration
{
    public interface ILikeService : IEntityService<LikeViewModel>
    {
        Task<List<LikeViewModel>> LikesByRoom(int roomId);

        Task<List<LikeViewModel>> LikesByUser(int userId);
    }
}
