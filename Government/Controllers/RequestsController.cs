using Government.ApplicationServices.GetFields;
using Government.ApplicationServices.RequestServices;
using Government.Contracts.Request;
using Government.Contracts.Request.Submiting;
using Government.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Government.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestsController(IRequestService requestService, AppDbContext context, IFieldService fieldService) : ControllerBase
    {
        private readonly IRequestService _requestService = requestService;
        private readonly AppDbContext _context = context;
        private readonly IFieldService fieldService = fieldService;

       


        [HttpGet("GetUserRequestsById")]
       
        public async Task<IActionResult> GetUserRequests(CancellationToken cancellationToken)
        {

            var userRequests = await _requestService.GetUserRequestsDetails(cancellationToken);

            return Ok(userRequests.Value());

        }



        [HttpGet("{requestId}")]

        public async Task<IActionResult> GetRequest([FromRoute] int requestId,CancellationToken cancellationToken)
        {

            var result = await _requestService.GetRequestAsync(requestId, cancellationToken);

            return result.IsSuccess ? Ok(result.Value()): result.ToProblem(statuscode:StatusCodes.Status404NotFound);

        }



        [HttpGet("")]
        
        public async Task<IActionResult> GetRequestByStatus([FromQuery] string requestStatus, CancellationToken cancellationToken)
        {

            var result = await _requestService.GetRequestByStatusAsync(requestStatus, cancellationToken);

            return Ok(result.Value());
        }


        [HttpGet]
        [Route("{serviceId}/fields")]
        public async Task<IActionResult> GetFields([FromRoute] int serviceId, CancellationToken cancellationToken)
        {

            var result = await fieldService.GetFieldAsync(serviceId, cancellationToken);

            return result.IsSuccess ?
                        Ok(result.Value())
                      : result.ToProblem(statuscode: StatusCodes.Status404NotFound);
        }

        [HttpGet]
        [Route("{serviceId}/documents")]
        public async Task<IActionResult> GetDocuments([FromRoute] int serviceId, CancellationToken cancellationToken)
        {

            var result = await fieldService.GetDocumentsAsync(serviceId, cancellationToken);

            return result.IsSuccess ?
                        Ok(result.Value())
                      : result.ToProblem(statuscode: StatusCodes.Status404NotFound);
        }


        [HttpPost("submit")]
        [AllowAnonymous]
        public async Task<IActionResult> SubmitServiceRequest([FromForm] SubmitRequestDto requestDto , CancellationToken cancellationToken)
        {
            var result = await _requestService.SubmitRequestAsync(requestDto, cancellationToken);

            return result.IsSuccess ? Ok(result.Value()) : result.ToProblem(statuscode: StatusCodes.Status500InternalServerError);

        }

    }
}

