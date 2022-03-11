using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : BaseEntityController<ChatMessageViewModel>
    {
        public ChatMessageController(IChatMessageService service)
            : base(service)
        {
        }
    }
}
