using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class HotelOptionRepository : BaseRepository<HotelOption>, IHotelOptionRepository
    {
        public HotelOptionRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<HotelOption> DefaultOrder(IQueryable<HotelOption> set)
        {
            return set.OrderBy(x => x.Name);
        }
    }
}
