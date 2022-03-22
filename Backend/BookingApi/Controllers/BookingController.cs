using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using System.Collections.Generic;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : BaseEntityController<BookingViewModel>
    {
        public BookingController(IBookingService service)
            : base(service)
        {
        }

        [Authorize]
        public override int GetCount()
        {
            return base.GetCount();
        }

        [Authorize]
        public override BookingViewModel Get(int id)
        {
            return base.Get(id);
        }

        [Authorize]
        public override IEnumerable<BookingViewModel> Get([FromQuery] int? limit, [FromQuery] int? page)
        {
            return base.Get(limit, page);
        }
    }
}
