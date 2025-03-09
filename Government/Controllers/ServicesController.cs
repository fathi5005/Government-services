using Government.ApplicationServices.GovernmentServices;
using Government.Contracts.Services;
using Government.Errors;
using Microsoft.AspNetCore.Authorization;


namespace Government.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServicesController(IService service, IWebHostEnvironment environment) : ControllerBase
    {
        private readonly IService _service = service;
        private readonly IWebHostEnvironment environment = environment;

        [HttpGet]
        [Route("All")]
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
        public async Task<IActionResult> GetService([FromRoute] int id, CancellationToken cancellationToken)
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
                      : result.ToProblem(statuscode: StatusCodes.Status404NotFound);

        }


        [HttpPut("Update/{id}")]

        public async Task<IActionResult> UpdateService([FromRoute] int id, [FromBody] AddServiceRequest request, CancellationToken cancellationToken)
        {

            var result = await _service.UpdateServiceAsync(id, request, cancellationToken);

            if (result.IsSuccess)
                return NoContent();

            return (result.Error.Equals(ServiceError.DuplicatingNameOrDescription))
                     ? result.ToProblem(statuscode: StatusCodes.Status409Conflict)
                     : result.ToProblem(statuscode: StatusCodes.Status404NotFound);
        }


        [HttpGet("MostRequestedServices")]
        [AllowAnonymous]
        public async Task<IActionResult> GetServiceStatistics()
        {
            var result = await _service.GetMostRequestedServicesAsync();
            return Ok(result.Value());
        }




        //[HttpPost("upload")]
        //public async Task<IActionResult> UploadFile(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return BadRequest("No file uploaded.");

        //    // التحقق من أن الملف PDF فقط
        //    if (Path.GetExtension(file.FileName).ToLower() != ".pdf")
        //        return BadRequest("Only PDF files are allowed.");

        //    // الحد الأقصى لحجم الملف (مثلاً 5MB)
        //    if (file.Length > 5 * 1024 * 1024)
        //        return BadRequest("File size exceeds 5MB.");

        //    // مسار الحفظ في wwwroot/docs
        //    var uploadsFolder = Path.Combine(environment.WebRootPath, "docs");
        //    if (!Directory.Exists(uploadsFolder))
        //        Directory.CreateDirectory(uploadsFolder);

        //    // اسم الملف الفريد لتجنب التكرار
        //    var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        //    var filePath = Path.Combine(uploadsFolder, fileName);

        //    // حفظ الملف
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    // إرجاع رابط الملف
        //    var fileUrl = $"https://government-services.runasp.net/docs/{fileName}";
        //    return Ok(new { FileUrl = fileUrl });
        //}






    }
}
