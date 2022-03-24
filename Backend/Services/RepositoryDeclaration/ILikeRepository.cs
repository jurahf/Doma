using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.RepositoryDeclaration
{
    public interface ILikeRepository : IRepository<Like>
    {
        Task<List<Like>> LikesByHotel(int hotelId);

        Task<List<Like>> LikesByUser(int userId);
    }
}
