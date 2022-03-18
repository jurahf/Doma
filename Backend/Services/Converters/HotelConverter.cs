using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class HotelConverter : IEntityViewModelConverter<HotelViewModel, Hotel>
    {
        private readonly IEntityViewModelConverter<FeedbackViewModel, Feedback> feedbackConverter;
        private readonly IEntityViewModelConverter<EmployeeViewModel, Employee> employeeConverter;
        private readonly IEntityViewModelConverter<RoomViewModel, Room> roomConverter;
        private readonly IEntityViewModelConverter<HotelOptionViewModel, HotelOption> optionConverter;

        public HotelConverter(
            IEntityViewModelConverter<FeedbackViewModel, Feedback> feedbackConverter,
            IEntityViewModelConverter<EmployeeViewModel, Employee> employeeConverter,
            IEntityViewModelConverter<RoomViewModel, Room> roomConverter,
            IEntityViewModelConverter<HotelOptionViewModel, HotelOption> optionConverter)
        {
            this.feedbackConverter = feedbackConverter;
            this.employeeConverter = employeeConverter;
            this.roomConverter = roomConverter;
            this.optionConverter = optionConverter;
        }

        public Hotel ConvertToStoredModel(HotelViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            Hotel result = new Hotel()
            {
                Id = viewModel.Id,
                Address = viewModel.Address,
                City = new City() { Id = viewModel.City?.Id ?? 0, Name = viewModel.City?.Name },
                CityId = viewModel.City?.Id ?? 0,
                Latitude = viewModel.Latitude,
                Longitude = viewModel.Longitude,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Stars = viewModel.Stars,
                Type = (StoredModel.Enums.HotelType)(int)viewModel.Type,
                Employees = withRelations 
                    ? viewModel.Employees.Select(x => employeeConverter.ConvertToStoredModel(x)).ToList() 
                    : new List<Employee>(),
                Feedbacks = withRelations 
                    ? viewModel.Feedbacks.Select(x => feedbackConverter.ConvertToStoredModel(x)).ToList()
                    : new List<Feedback>(),
                Rooms = withRelations
                    ? viewModel.Rooms.Select(x => roomConverter.ConvertToStoredModel(x)).ToList()
                    : new List<Room>(),
            };

            result.HotelOptions = withRelations
                ? viewModel.HotelOptions
                    .Select(x => new HotelHotelOption()
                    {
                        Hotel = result,
                        HotelId = result.Id,
                        HotelOption = optionConverter.ConvertToStoredModel(x),
                        HotelOptionId = x.Id
                    })
                    .ToList()
                : new List<HotelHotelOption>();

            return result;
        }

        public HotelViewModel ConvertToViewModel(Hotel dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            HotelViewModel result = new HotelViewModel()
            {
                Id = dbModel.Id,
                Address = dbModel.Address,
                City = new CityViewModel() { Id = dbModel.City?.Id ?? 0, Name = dbModel.City?.Name },
                Latitude = dbModel.Latitude,
                Longitude = dbModel.Longitude,
                Name = dbModel.Name,
                Description = dbModel.Description,
                Stars = dbModel.Stars,
                Type = (ViewModel.Enums.HotelType)(int)dbModel.Type,
                Employees = withRelations
                    ? dbModel.Employees.Select(x => employeeConverter.ConvertToViewModel(x)).ToList()
                    : new List<EmployeeViewModel>(),
                Feedbacks = withRelations
                    ? dbModel.Feedbacks.Select(x => feedbackConverter.ConvertToViewModel(x)).ToList()
                    : new List<FeedbackViewModel>(),
                Rooms = withRelations
                    ? dbModel.Rooms.Select(x => roomConverter.ConvertToViewModel(x)).ToList()
                    : new List<RoomViewModel>(),
            };

            result.HotelOptions = withRelations
                ? dbModel.HotelOptions
                    .Select(x => optionConverter.ConvertToViewModel(x.HotelOption))
                    .ToList()
                : new List<HotelOptionViewModel>();

            return result;
        }
    }
}
