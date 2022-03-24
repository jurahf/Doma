using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.RepositoryDeclaration
{
    public interface ILikeRepository : IRepository<Like>
    {
        Task<List<Like>> LikesByRoom(int roomId);

        Task<List<Like>> LikesByUser(int userId);
    }
}
