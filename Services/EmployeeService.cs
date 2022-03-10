using Services.Converters;
using Services.RepositoryDeclaration;
using Services.ServiceDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services
{
    public class EmployeeService : BaseEntityService<EmployeeViewModel, Employee>, IEmployeeService
    {
        public EmployeeService(
            IEmployeeRepository repository,
            IEntityViewModelConverter<EmployeeViewModel, Employee> converter)
            : base(repository, converter)
        {
        }
    }
}