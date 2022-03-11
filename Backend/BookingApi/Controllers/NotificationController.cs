using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseEntityController<NotificationViewModel>
    {
        public NotificationController(INotificationService service)
            : base(service)
        {
        }
    }
}
