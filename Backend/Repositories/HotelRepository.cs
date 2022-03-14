using Microsoft.EntityFrameworkCore;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<Hotel> DefaultOrder(IQueryable<Hotel> set)
        {
            return set.OrderBy(x => x.Name);
        }

        protected override IQueryable<Hotel> Fetch(IQueryable<Hotel> set)
        {
            return set
                .Include(x => x.Feedbacks)
                .Include(x => x.Employees)
                    .ThenInclude(x => x.User)
                .Include(x => x.HotelOptions)
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.Bookings)
                .Include(x => x.City);
        }
    }
}
