using Microsoft.EntityFrameworkCore;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<Feedback> DefaultOrder(IQueryable<Feedback> set)
        {
            return set.OrderByDescending(x => x.DateTime);
        }

        protected override IQueryable<Feedback> Fetch(IQueryable<Feedback> set)
        {
            return set
                .Include(x => x.Booking)
                .Include(x => x.Hotel);
        }
    }
}
