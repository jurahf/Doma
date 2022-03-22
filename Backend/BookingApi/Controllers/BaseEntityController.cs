using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.ServiceDeclaration;
using System.Collections.Generic;
using System.Security.Claims;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
        where T : IViewModel
    {
        private readonly IEntityService<T> service;

        public BaseEntityController(IEntityService<T> service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetCount")]
        public virtual int GetCount()
        {
            return service.GetCount();
        }

        [HttpGet]
        public virtual IEnumerable<T> Get([FromQuery] int? limit, [FromQuery] int? page)
        {
            return service.Get(limit ?? 100, page ?? 0);
        }

        [HttpGet("{id}")]
        public virtual T Get(int id)
        {
            return service.Get(id);
        }

        [HttpPost]
        [Authorize]
        public virtual int Post([FromBody] T value)
        {
            return service.Add(value);
        }

        [HttpPut("{id}")]
        [Authorize]
        public virtual void Put(int id, [FromBody] T value)
        {
            value.Id = id;
            service.Update(value);
        }


        [HttpDelete("{id}")]
        [Authorize]
        public virtual void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
