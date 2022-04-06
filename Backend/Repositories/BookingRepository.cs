using Microsoft.EntityFrameworkCore;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(BookingDatabaseContext dbContext)
            : base(dbContext)
        {
        }

        protected override IQueryable<Booking> DefaultOrder(IQueryable<Booking> set)
        {
            return set.OrderBy(x => x.StartDate);
        }

        protected override IQueryable<Booking> Fetch(IQueryable<Booking> set)
        {
            return set
                .Include(x => x.Client)
                .Include(x => x.Feedback)
                .Include(x => x.Room)
                    .ThenInclude(x => x.Hotel)
                .Include(x => x.Options)
                    .ThenInclude(x => x.HotelOption);
        }

        protected override void ReLoadRelations(Booking entity)
        {
            entity.Client = null;
            entity.Room = null;
        }
    }
}
