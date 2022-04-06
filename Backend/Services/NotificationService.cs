using Services.Converters;
using Services.EmailSending;
using Services.RepositoryDeclaration;
using Services.ServiceDeclaration;
using StoredModel;
using StoredModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
    public class NotificationService : BaseEntityService<NotificationViewModel, Notification>, INotificationService
    {
        private readonly INotificationRepository notifRepository;
        private readonly IBookingRepository bookingRepository;
        private readonly IChatMessageRepository chatMessageRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmailSender emailSender;


        public NotificationService(
            INotificationRepository notifRepository,
            IBookingRepository bookingRepository,
            IChatMessageRepository chatMessageRepository,
            IEmployeeRepository employeeRepository,
            IEmailSender emailSender,
            IEntityViewModelConverter<NotificationViewModel, Notification> converter)
            : base(notifRepository, converter)
        {
            this.notifRepository = notifRepository;
            this.bookingRepository = bookingRepository;
            this.chatMessageRepository = chatMessageRepository;
            this.employeeRepository = employeeRepository;
            this.emailSender = emailSender;
        }


        public async Task CreateNewBookingEvent(int bookingId, int initorUserId)
        {
            Booking booking = bookingRepository.GetById(bookingId);
            List<Employee> employees = employeeRepository.GetByHotel(booking.Room.Hotel.Id);
            // проверяем initorId, чтобы отправлял только нужный пользователь
            if (booking.Client.Id != initorUserId
                && !employees.Any(x => x.User.Id == initorUserId))
            {
                return;
            }

            // создаем уведомления
            Notification notificationToClient = new Notification()
            {
                Type = NotificationType.BookingCreated,
                DateTime = DateTime.Now,
                Status = NotificationStatus.NotSended,
                Reciver = booking.Client, 
                UserId = booking.Client.Id,
                Title = "Новое бронирование",
                Text = $"Вы создали заявку на бронирование отеля {booking.Room.Hotel.Name} с {booking.StartDate:dd.MM.yyyy} по {booking.EndDate:dd.MM.yyyy}. Дождитесь подтверждения бронирования, или свяжитесь с отелем в чате."
            };

            notifRepository.Add(notificationToClient);

            List<Notification> hotelNotifications = new List<Notification>();
            foreach (var employee in employees)
            {
                hotelNotifications.Add(new Notification()
                {
                    Type = NotificationType.BookingCreated,
                    DateTime = DateTime.Now,
                    Status = NotificationStatus.NotSended,
                    Reciver = employee.User,
                    UserId = employee.User.Id,
                    Title = "Новое бронирование",
                    Text = $"Пользователь {booking.Client.Name} создал бронирование отеля {booking.Room.Hotel.Name} с {booking.StartDate:dd.MM.yyyy} по {booking.EndDate:dd.MM.yyyy}. Подтвердите бронирование или свяжитесь с клиентом в чате."
                });
            }

            // TODO: как выбрать человека из отеля?
            ChatMessage chatMessage = new ChatMessage()
            {
                Author = employees.FirstOrDefault()?.User,
                DateTime = DateTime.Now,
                Reciver = booking.Client,
                Status = ChatMessageStatus.Sended,
                Text = $"{notificationToClient.Title}{Environment.NewLine}{notificationToClient.Text}",
            };

            chatMessageRepository.Add(chatMessage);

            // отправялем письма
            foreach (var notif in hotelNotifications)
            {
                await ProcessNotification(notif);
            }
            await ProcessNotification(notificationToClient);
        }


        private async Task ProcessNotification(Notification notif)
        {
            try
            {
                if (notif.Status == NotificationStatus.Sended)
                    return;

                await emailSender.SendEmailAsync(notif.Reciver.Email, notif.Title, notif.Text);

                notif.Status = NotificationStatus.Sended;
                notifRepository.Update(notif);
            }
            catch (Exception ex)
            {
                // не отправили письма - ничего, можем отправить потом
                // TODO: отправлять потом, лол
                // TODO: log
            }

        }

    }
}