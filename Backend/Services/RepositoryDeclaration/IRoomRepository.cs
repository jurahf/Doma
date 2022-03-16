using Services.Parameters;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.RepositoryDeclaration
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<List<Room>> SearchRooms(SearchRoomsFilter filter);
    }
}
