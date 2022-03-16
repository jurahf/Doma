using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Parameters;
using Services.ServiceDeclaration;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : BaseEntityController<RoomViewModel>
    {
        private readonly IRoomService service;

        public RoomController(IRoomService service)
            : base(service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("SearchRooms")]
        public async Task<List<RoomViewModel>> SearchRooms([FromBody] SearchRoomsFilter filter)
        {
            return await service.SearchRooms(filter);
        }

    }
}
