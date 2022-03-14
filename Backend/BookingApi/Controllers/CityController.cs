using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseEntityController<CityViewModel>
    {
        public CityController(ICityService service)
            : base(service)
        {
        }
    }
}
