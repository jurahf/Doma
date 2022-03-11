using Microsoft.EntityFrameworkCore;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class SupportRequestRepository : BaseRepository<SupportRequest>, ISupportRequestRepository
    {
        public SupportRequestRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<SupportRequest> DefaultOrder(IQueryable<SupportRequest> set)
        {
            return set.OrderBy(x => x.DateTime);
        }

        protected override IQueryable<SupportRequest> Fetch(IQueryable<SupportRequest> set)
        {
            return set
                .Include(x => x.User);
        }
    }
}
