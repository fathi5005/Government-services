using Government.Abstractions;
using Government.ApplicationServices.GetFields;
using Government.ApplicationServices.GovernmentServices;
using Government.Contracts.Services;
using Government.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Government.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServicesController(IService service) : ControllerBase
    {
        private readonly IService _service = service;

        [HttpGet]
        [Route ("All")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllServices(CancellationToken cancellationToken)
        {

            var services = await _service.GetAllServicesAsync(cancellationToken);
            return Ok(services.Value());
        }


        [HttpGet]
        [Route("available")]
        public async Task<IActionResult> GetAvailableServices(CancellationToken cancellationToken)
        {

            var services = await _service.GetAllAvailableServicesAsync(cancellationToken);
            return Ok(services.Value());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetService([FromRoute] int id,CancellationToken cancellationToken)
        {

            var services = await _service.GetServicesByIdAsync(id, cancellationToken);

           
            return services.IsSuccess ?
                            Ok(services.Value()) :
                            services.ToProblem(statuscode: StatusCodes.Status404NotFound);
        }



        [HttpPost("Add")]
      
        public async Task<IActionResult> AddService([FromBody] AddServiceRequest request, CancellationToken cancellationToken)
        {

            var result = await _service.AddServiceAsync(request, cancellationToken);


            return result.IsSuccess ?
                        Ok(result.Value())
                      : result.ToProblem(statuscode: StatusCodes.Status409Conflict);


        }



        [HttpPut("Toggle/{id}")]

        public async Task<IActionResult> ToggleService([FromRoute] int id, CancellationToken cancellationToken)

        {

            var result = await _service.ToggleServiceAsync(id, cancellationToken);

            return result.IsSuccess ? 
                        NoContent()
                      : result.ToProblem(statuscode:StatusCodes.Status404NotFound);

        }


        [HttpPut("Update/{id}")]

        public async Task<IActionResult> UpdateService([FromRoute]int id , [FromBody] AddServiceRequest request, CancellationToken cancellationToken)
        {

            var result = await _service.UpdateServiceAsync(id, request, cancellationToken);

            if (result.IsSuccess)
                return NoContent();

            return ( result.Error.Equals(ServiceError.DuplicatingNameOrDescription))
                     ? result.ToProblem(statuscode: StatusCodes.Status409Conflict)
                     : result.ToProblem(statuscode: StatusCodes.Status404NotFound);
        }




    }


}
