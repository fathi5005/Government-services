using Government.ApplicationServices.RequestServices;
using Government.Contracts.Request;
using Government.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Government.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly AppDbContext _context;


        public RequestsController(IRequestService requestService, AppDbContext context)
        {
            _requestService = requestService;
            _context = context;
        }

        [HttpPost]
        [Route("{ServiceId}")]
        [Authorize]
        public async Task<IActionResult> AddRequest([FromBody] RequestDto requestDto, CancellationToken cancellationToken)
        {


             var requestResponse = await _requestService.AddRequestAsync(requestDto, cancellationToken);


            if (!requestResponse.IsSuccess)
            {
                return NotFound(requestResponse.Error);
            }

            return Ok(requestResponse.Value());

        }


        [HttpGet("GetUserRequestsById")]
        [Authorize]
        public async Task<IActionResult> GetUserRequests(CancellationToken cancellationToken)
        {

            var userRequests = await _requestService.GetUserRequestsDetails(cancellationToken);

            return Ok(userRequests.Value());

        }
    }
}

