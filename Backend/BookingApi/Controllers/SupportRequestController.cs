using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportRequestController : BaseEntityController<SupportRequestViewModel>
    {
        public SupportRequestController(ISupportRequestService service)
            : base(service)
        {
        }
    }
}
