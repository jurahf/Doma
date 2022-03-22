using Microsoft.EntityFrameworkCore;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public User GetByIdentityName(string identityName)
        {
            return Fetch(dbContext.Users)
                .FirstOrDefault(x => x.Email.ToLower() == identityName.ToLower());
        }

        protected override IQueryable<User> DefaultOrder(IQueryable<User> set)
        {
            return set.OrderBy(x => x.Name);
        }

        protected override IQueryable<User> Fetch(IQueryable<User> set)
        {
            return set
                .Include(x => x.Employees)
                    .ThenInclude(x => x.Hotel)
                .Include(x => x.Bookings)
                    .ThenInclude(x => x.Room)
                    .ThenInclude(x => x.Hotel)
                .Include(x => x.SupportRequests)
                .Include(x => x.Notifications)
                .Include(x => x.IncomingMessages)
                    .ThenInclude(x => x.Author)
                .Include(x => x.OutcomingMessages)
                    .ThenInclude(x => x.Reciver);
        }
    }
}
