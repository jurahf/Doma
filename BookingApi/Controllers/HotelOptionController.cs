using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelOptionController : BaseEntityController<HotelOptionViewModel>
    {
        public HotelOptionController(IHotelOptionService service)
            : base(service)
        {
        }
    }
}
