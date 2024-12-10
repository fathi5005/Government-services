using Government.ApplicationServices.GovernmentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Government.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IService _service;

        public ServicesController(IService service )
        {
            _service = service;
        }

        [HttpGet]
        [Route ("GetAllServices")]
        [Authorize]

        public async Task<IActionResult> GetAllServicesAsync(CancellationToken cancellationToken)
        {

            var services = await _service.GetServicesAsync(cancellationToken);
            return Ok(services);
        }

    }
}
