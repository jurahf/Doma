using Microsoft.EntityFrameworkCore;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<Employee> Fetch(IQueryable<Employee> set)
        {
            return set
                .Include(x => x.User)
                .Include(x => x.Hotel);
        }
    }
}
