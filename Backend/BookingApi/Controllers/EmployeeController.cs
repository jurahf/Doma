using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceDeclaration;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseEntityController<EmployeeViewModel>
    {
        public EmployeeController(IEmployeeService service)
            : base(service)
        {
        }
    }
}
