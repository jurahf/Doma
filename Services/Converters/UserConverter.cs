using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class UserConverter : IEntityViewModelConverter<UserViewModel, User>
    {
        private readonly IEntityViewModelConverter<BookingViewModel, Booking> bookingConverter;
        private readonly IEntityViewModelConverter<EmployeeViewModel, Employee> employeeConverter;
        private readonly IEntityViewModelConverter<ChatMessageViewModel, ChatMessage> messageConverter;
        private readonly IEntityViewModelConverter<NotificationViewModel, Notification> notificationConverter;
        private readonly IEntityViewModelConverter<SupportRequestViewModel, SupportRequest> supportRequestConverter;

        public UserConverter(
            IEntityViewModelConverter<BookingViewModel, Booking> bookingConverter,
            IEntityViewModelConverter<EmployeeViewModel, Employee> employeeConverter,
            IEntityViewModelConverter<ChatMessageViewModel, ChatMessage> messageConverter,
            IEntityViewModelConverter<NotificationViewModel, Notification> notificationConverter,
            IEntityViewModelConverter<SupportRequestViewModel, SupportRequest> supportRequestConverter)
        {
            this.bookingConverter = bookingConverter;
            this.employeeConverter = employeeConverter;
            this.messageConverter = messageConverter;
            this.notificationConverter = notificationConverter;
            this.supportRequestConverter = supportRequestConverter;
        }

        public User ConvertToStoredModel(UserViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            return new User()
            {
                Id = viewModel.Id,
                Email = viewModel.Email,
                Name = viewModel.Name,
                PasswordHash = viewModel.PasswordHash,
                PhoneNumber = viewModel.PhoneNumber,
                Bookings = withRelations 
                    ? viewModel.Bookings.Select(x => bookingConverter.ConvertToStoredModel(x)).ToList() 
                    : new List<Booking>(),
                Employees = withRelations
                    ? viewModel.Employees.Select(x => employeeConverter.ConvertToStoredModel(x)).ToList() 
                    : new List<Employee>(),
                IncomingMessages = withRelations
                    ? viewModel.IncomingMessages.Select(x => messageConverter.ConvertToStoredModel(x)).ToList()
                    : new List<ChatMessage>(),
                OutcomingMessages = withRelations
                    ? viewModel.OutcomingMessages.Select(x => messageConverter.ConvertToStoredModel(x)).ToList()
                    : new List<ChatMessage>(),
                Notifications = withRelations
                    ? viewModel.Notifications.Select(x => notificationConverter.ConvertToStoredModel(x)).ToList()
                    : new List<Notification>(),
                SupportRequests = withRelations
                    ? viewModel.SupportRequests.Select(x => supportRequestConverter.ConvertToStoredModel(x)).ToList()
                    : new List<SupportRequest>(),
            };
        }

        public UserViewModel ConvertToViewModel(User dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            return new UserViewModel()
            {
                Id = dbModel.Id,
                Email = dbModel.Email,
                Name = dbModel.Name,
                PasswordHash = dbModel.PasswordHash,
                PhoneNumber = dbModel.PhoneNumber,
                Bookings = withRelations
                    ? dbModel.Bookings.Select(x => bookingConverter.ConvertToViewModel(x)).ToList()
                    : new List<BookingViewModel>(),
                Employees = withRelations
                    ? dbModel.Employees.Select(x => employeeConverter.ConvertToViewModel(x)).ToList()
                    : new List<EmployeeViewModel>(),
                IncomingMessages = withRelations
                    ? dbModel.IncomingMessages.Select(x => messageConverter.ConvertToViewModel(x)).ToList()
                    : new List<ChatMessageViewModel>(),
                OutcomingMessages = withRelations
                    ? dbModel.OutcomingMessages.Select(x => messageConverter.ConvertToViewModel(x)).ToList()
                    : new List<ChatMessageViewModel>(),
                Notifications = withRelations
                    ? dbModel.Notifications.Select(x => notificationConverter.ConvertToViewModel(x)).ToList()
                    : new List<NotificationViewModel>(),
                SupportRequests = withRelations
                    ? dbModel.SupportRequests.Select(x => supportRequestConverter.ConvertToViewModel(x)).ToList()
                    : new List<SupportRequestViewModel>(),
            };
        }
    }
}
