using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.RepositoryDeclaration
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        List<Employee> GetByHotel(int hotelId);
    }
}
