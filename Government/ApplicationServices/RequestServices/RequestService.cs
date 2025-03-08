using Government.Contracts.Request;
using Government.Contracts.Request.Submiting;
using Government.Entities;
using Government.Errors;
using Mapster;
using System.Linq;
using System.Security.Claims;

namespace Government.ApplicationServices.RequestServices
{
    public class RequestService(AppDbContext context, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env, ILogger<RequestService> logger) : IRequestService
    {
        private readonly AppDbContext _context = context;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IWebHostEnvironment env = env;
        private readonly ILogger<RequestService> logger = logger;

        /*
public async Task<Result<AddRequestResponseDto>> AddRequestAsync(AddRequestDto requestDto, CancellationToken cancellationToken)
{
var UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

var IsServiceExist = await _context.Services
.Where(x => x.Id == requestDto.ServiceId)
.AsNoTracking()
.SingleOrDefaultAsync(cancellationToken);

if (IsServiceExist is null)
return Result.Falire<AddRequestResponseDto>(ServiceError.ServiceNotFound);

var newRequest = new Request()
{
ServiceId = requestDto.ServiceId,
UserId = UserId!,
RequestDate = DateTime.UtcNow,
};

await _context.Requests.AddAsync(newRequest, cancellationToken);

await _context.SaveChangesAsync(cancellationToken);

var AddRequestResponseDto = await _context.Requests
.Where(r => r.Id == newRequest.Id)
.Select(x => new AddRequestResponseDto(
x.Id,
x.service.ServiceName,
x.RequestDate,
x.RequestStatus,
x.RequestStatus

))
.AsNoTracking()
.SingleOrDefaultAsync(cancellationToken);   

return Result.Success(AddRequestResponseDto)!;

}
*/
        public async Task<Result<RequestDetailsResponse>> GetRequestAsync(int requestId, CancellationToken cancellationToken)
        {

            var request = await _context.Requests
                                  .Where(r => r.Id == requestId)
                                  .Select(x => new RequestDetailsResponse(
                                          x.Id,
                                          x.UserId,
                                          x.service.ServiceName,
                                          x.RequestDate,
                                          x.RequestStatus,
                                          x.ResponseStatus,
                                          x.AdminResponse.ResponseText ?? "No Response",
                                          x.AttachedDocuments.Select(a => a.FileName), /* اعادة الفايل نفسة*/
                                          x.Payments.Select(p => p.PaymentStatus)
                                          )
                                         ).AsNoTracking()
                                          .SingleOrDefaultAsync(cancellationToken);



            if (request == null)
            {
                return Result.Falire<RequestDetailsResponse>(ServiceError.ServiceNotFound);
            }

         return Result.Success(request);

        }

        public async Task<Result<IEnumerable<RequestsDetailstoUser>>> GetUserRequestsDetails(CancellationToken cancellationToken)
        {

            var UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
           

            var userRequests = await _context.Requests
                                 .Where(x => x.UserId == UserId)
                                 .Select(x=> new RequestsDetailstoUser(
                                     x.Id,
                                     x.service.ServiceName,
                                     x.RequestDate,
                                     x.RequestStatus,
                                     x.ResponseStatus,
                                     x.AdminResponse.ResponseText                       
                                     ))
                                 .AsNoTracking()
                                 .ToListAsync();


            //if (userRequests == null || !userRequests.Any())
            //{
            //    IEnumerable<RequestsDetailstoUser> emptyList = new List<RequestsDetailstoUser>();

            //    return Result.Success(emptyList); // empty list 
            //}

            //var ReqResponse = userRequests.Adapt<IEnumerable<RequestsDetailstoUser>>();

            return Result.Success<IEnumerable<RequestsDetailstoUser>>(userRequests);

        }


        public async  Task<Result<IEnumerable<RequestsDetailstoUser>>> GetRequestByStatusAsync(string request, CancellationToken cancellationToken)
        {

            var UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var requests = await _context.Requests.Where(r => r.UserId == UserId && r.RequestStatus == request) 
                        .Select(x => new RequestsDetailstoUser(
                            x.Id,
                            x.service.ServiceName,
                            x.RequestDate,
                            x.RequestStatus,
                            x.ResponseStatus,
                            x.AdminResponse.ResponseText ?? "No response yet"
                            )
                            )
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);
            logger.LogInformation($"UserId: {UserId}, RequestStatus: {request}");


            return Result.Success<IEnumerable<RequestsDetailstoUser>>(requests);
                                
        }

        public async Task<Result<SubmitResponseDto>> SubmitRequestAsync(SubmitRequestDto requestDto, CancellationToken cancellationToken)
        {
           // var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
         

            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var request = new Request
                {
                    RequestDate = DateTime.UtcNow,
                    UserId = requestDto.UserId,
                    ServiceId = requestDto.ServiceId,
                    AttachedDocuments = new List<AttachedDocument>(),
                    serviceData = new List<ServiceData>()
                };

                await _context.Requests.AddAsync(request, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);


                var serviceDataList = requestDto.ServiceData.Select(sd => new ServiceData
                {
                    RequestId = request.Id,
                    FieldId = sd.FieldId,
                    FieldValueString = sd.FieldValueString,
                    FieldValueInt = sd.FieldValueInt,
                    FieldValueFloat = sd.FieldValueFloat,
                    FieldValueDate = sd.FieldValueDate
                }).ToList();

   

                 await _context.ServicesData.AddRangeAsync(serviceDataList, cancellationToken);
        
                await _context.SaveChangesAsync(cancellationToken);

                
                if (requestDto.Files != null && requestDto.Files.Any())
                {

                    var attachedDocuments = new List<AttachedDocument>();
                    foreach (var file in requestDto.Files)
                    {
                        var filePath = await SaveFile(file);
                        attachedDocuments.Add(new AttachedDocument
                        {
                            RequestId = request.Id,
                            FileName = file.FileName,
                            FileUrl = filePath,
                            UploadedAt = DateTime.UtcNow,
                            IsVerified = false
                        });
                    }

                    await _context.AttachedDocuments.AddRangeAsync(attachedDocuments, cancellationToken);
                }

                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                return Result.Success(new SubmitResponseDto(request.Id));
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                logger.LogError(ex, "Error submitting request");

                return Result.Falire<SubmitResponseDto>(RequestErrors.RequestNotCompleted);
            }
        }


        private async Task<string> SaveFile(IFormFile file)
        {
            // تحديد المسار الافتراضي إذا كان WebRootPath فارغًا
            var uploadsFolder = Path.Combine(env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "uploads");

            // التأكد من وجود المجلد
            Directory.CreateDirectory(uploadsFolder);

            // إنشاء اسم عشوائي للملف
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            // حفظ الملف
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{fileName}";
        }


    }
}

