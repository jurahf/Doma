using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : BaseEntityController<RoomViewModel>
    {
        public RoomController(IRoomService service)
            : base(service)
        {
        }
    }
}
