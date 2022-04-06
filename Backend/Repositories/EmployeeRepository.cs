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

        public List<Employee> GetByHotel(int hotelId)
        {
            return Fetch(
                    DefaultOrder(dbContext.Employees)
                    .Where(x => x.Hotel.Id == hotelId))
                .ToList();
        }

        protected override IQueryable<Employee> Fetch(IQueryable<Employee> set)
        {
            return set
                .Include(x => x.User)
                .Include(x => x.Hotel);
        }
    }
}
