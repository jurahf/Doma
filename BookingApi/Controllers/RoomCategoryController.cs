using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomCategoryController : BaseEntityController<RoomCategoryViewModel>
    {
        public RoomCategoryController(IRoomCategoryService service)
            : base(service)
        {
        }
    }
}
