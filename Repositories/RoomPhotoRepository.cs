using Microsoft.EntityFrameworkCore;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class RoomPhotoRepository : BaseRepository<RoomPhoto>, IRoomPhotoRepository
    {
        public RoomPhotoRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<RoomPhoto> Fetch(IQueryable<RoomPhoto> set)
        {
            return set
                .Include(x => x.Room);
        }
    }
}
