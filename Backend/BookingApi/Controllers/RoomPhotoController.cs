using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomPhotoController : BaseEntityController<RoomPhotoViewModel>
    {
        public RoomPhotoController(IRoomPhotoService service)
            : base(service)
        {
        }
    }
}
