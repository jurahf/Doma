using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class EmployeeConverter : IEntityViewModelConverter<EmployeeViewModel, Employee>
    {
        public Employee ConvertToStoredModel(EmployeeViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            return new Employee()
            {
                Id = viewModel.Id,
                Role = (StoredModel.Enums.EmployeeRole)(int)viewModel.Role,
                User = new User() { Id = viewModel.User?.Id ?? 0, Name = viewModel.User?.Name },
                UserId = viewModel.User?.Id ?? 0,
                Hotel = new Hotel() { Id = viewModel.Hotel?.Id ?? 0, Name = viewModel.Hotel?.Name },
                HotelId = viewModel.Hotel?.Id ?? 0
            };
        }

        public EmployeeViewModel ConvertToViewModel(Employee dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            return new EmployeeViewModel()
            {
                Id = dbModel.Id,
                Role = (ViewModel.Enums.EmployeeRole)(int)dbModel.Role,
                User = new UserViewModel() { Id = dbModel.User?.Id ?? 0, Name = dbModel.User?.Name },
                Hotel = new HotelViewModel() { Id = dbModel.Hotel?.Id ?? 0, Name = dbModel.Hotel?.Name },
            };
        }
    }
}
