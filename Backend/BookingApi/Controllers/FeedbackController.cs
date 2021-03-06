using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : BaseEntityController<FeedbackViewModel>
    {
        public FeedbackController(IFeedbackService service)
            : base(service)
        {
        }
    }
}
