using Government.ApplicationServices.Results;
using Government.Contracts.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Government.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController(IDashboardService dashboardService) : ControllerBase
    {
        private readonly IDashboardService dashboardService = dashboardService;

        [HttpGet("overview")]
        public async Task<ActionResult<Overview>> GetOverview()
        {
            var overview = await dashboardService.GetOverviewAsync();

            return Ok(overview.Value());
        }


        [HttpGet("requests")]
        public async Task<IActionResult> GetRequestStatistics()
        {
            var result = await dashboardService.GetRequestStatisticsAsync();

            return Ok(result.Value());
        }


        [HttpGet("services")]
        public async Task<IActionResult> GetServiceStatistics()
        {
            var result = await dashboardService.GetServiceStatisticsAsync();
            return Ok(result);
        }


    }
}
