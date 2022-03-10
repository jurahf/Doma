using Microsoft.EntityFrameworkCore;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<Notification> DefaultOrder(IQueryable<Notification> set)
        {
            return set.OrderBy(x => x.DateTime);
        }

        protected override IQueryable<Notification> Fetch(IQueryable<Notification> set)
        {
            return set
                .Include(x => x.Reciver);
        }
    }
}
