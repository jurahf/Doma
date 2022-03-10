using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : BaseEntityController<HotelViewModel>
    {
        public HotelController(IHotelService service)
            : base(service)
        {
        }
    }
}
