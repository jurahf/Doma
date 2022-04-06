using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Authorization;
using Services.Parameters;
using Services.ServiceDeclaration;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseEntityController<NotificationViewModel>
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService service)
            : base(service)
        {
            this.notificationService = service;
        }

        [Authorize]
        public override int GetCount()
        {
            return base.GetCount();
        }

        [Authorize]
        public override NotificationViewModel Get(int id)
        {
            return base.Get(id);
        }

        [Authorize]
        public override IEnumerable<NotificationViewModel> Get([FromQuery] int? limit, [FromQuery] int? page)
        {
            return base.Get(limit, page);
        }

        [HttpPost]
        [Authorize]
        [Route("CreateNewBookingEvent")]
        public async Task<bool> CreateNewBookingEvent([FromBody] CreateNewBookingEventRequest data)
        {
            string userIdStr = AuthorizationHelper.GetClaim(Request, AuthorizationHelper.UserIdClaimName);
            int.TryParse(userIdStr, out int userId);

            await notificationService.CreateNewBookingEvent(data.BookingId, userId);

            return true;
        }

    }
}
