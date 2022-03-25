using Microsoft.EntityFrameworkCore;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(BookingDatabaseContext dbContext)
            : base(dbContext)
        {
        }

        protected override IQueryable<Like> DefaultOrder(IQueryable<Like> set)
        {
            return set.OrderByDescending(x => x.Date);
        }

        protected override IQueryable<Like> Fetch(IQueryable<Like> set)
        {
            return set
                .Include(x => x.User)
                .Include(x => x.Room)
                    .ThenInclude(x => x.Hotel);
        }

        public async Task<List<Like>> LikesByRoom(int roomId)
        {
            return await Fetch(DefaultOrder(dbContext.Likes)
                .Where(x => x.Room.Id == roomId))
                .ToListAsync();
        }

        public async Task<List<Like>> LikesByUser(int userId)
        {
            return await Fetch(DefaultOrder(dbContext.Likes)
                .Where(x => x.User.Id == userId))
                .ToListAsync();
        }

        protected override void ReLoadRelations(Like entity)
        {
            entity.Room = null;
            entity.User = null;
        }
    }
}
