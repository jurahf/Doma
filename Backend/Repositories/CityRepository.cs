using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<City> DefaultOrder(IQueryable<City> set)
        {
            return set.OrderBy(x => x.Name);
        }
    }
}
