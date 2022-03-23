using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Authorization;
using Services.ServiceDeclaration;
using System.Collections.Generic;
using System.Security.Claims;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseEntityController<UserViewModel>
    {
        private readonly IUserService service;

        public UserController(IUserService service)
            : base(service)
        {
            this.service = service;
        }

        [Authorize]
        public override int GetCount()
        {
            return base.GetCount();
        }

        [Authorize]
        public override UserViewModel Get(int id)
        {
            return base.Get(id);
        }

        [Authorize]
        public override IEnumerable<UserViewModel> Get([FromQuery] int? limit, [FromQuery] int? page)
        {
            return base.Get(limit, page);
        }

        [Authorize]
        [HttpGet]
        [Route("GetByIdentityName")]
        public ActionResult<UserViewModel> GetByIdentityName(string identityName)
        {
            string login = AuthorizationHelper.GetClaim(Request, ClaimTypes.NameIdentifier);

            if (login != identityName)
                return Unauthorized();

            return service.GetByIdentityName(identityName);
        }
    }
}
