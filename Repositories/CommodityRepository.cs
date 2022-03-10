using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class CommodityRepository : BaseRepository<Commodity>, ICommodityRepository
    {
        public CommodityRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<Commodity> DefaultOrder(IQueryable<Commodity> set)
        {
            return set.OrderBy(x => x.Name);
        }
    }
}
