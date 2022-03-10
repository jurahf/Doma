using Microsoft.EntityFrameworkCore;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<Room> DefaultOrder(IQueryable<Room> set)
        {
            return set.OrderBy(x => x.Hotel.Name).ThenBy(x => x.CostPerDay);
        }

        protected override IQueryable<Room> Fetch(IQueryable<Room> set)
        {
            return set
                .Include(x => x.Hotel)
                .Include(x => x.Category)
                .Include(x => x.Photos)
                .Include(x => x.Commodities)
                .Include(x => x.Bookings);
        }
    }
}
