using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityController : BaseEntityController<CommodityViewModel>
    {
        public CommodityController(ICommodityService service)
            : base(service)
        {
        }
    }
}
