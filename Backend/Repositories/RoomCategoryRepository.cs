using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class RoomCategoryRepository : BaseRepository<RoomCategory>, IRoomCategoryRepository
    {
        public RoomCategoryRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<RoomCategory> DefaultOrder(IQueryable<RoomCategory> set)
        {
            return set.OrderBy(x => x.Name);
        }
    }
}
