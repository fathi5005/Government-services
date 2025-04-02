using Government.ApplicationServices.Files;
using Government.Contracts.Fields;
using Government.Contracts.Request;
using Government.Contracts.Request.Submiting;
using Government.Entities;
using Government.Errors;
using Mapster;
using System.Linq;
using System.Security.Claims;

namespace Government.ApplicationServices.RequestServices
{
    public class RequestService(AppDbContext context, IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment env, ILogger<RequestService> logger,
        IFileService fileService) : IRequestService
    {
        private readonly AppDbContext _context = context;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IWebHostEnvironment env = env;
        private readonly ILogger<RequestService> logger = logger;
        private readonly IFileService fileService = fileService;



        //public async Task<Result<RequestDetailsResponse>> GetRequestAsync(int requestId, CancellationToken cancellationToken)
        //{

        //    var request = await _context.Requests
        //                          .Where(r => r.Id == requestId)
        //                          .Select(x => new RequestDetailsResponse(
        //                                  x.Id,
        //                                  x.UserId,
        //                                  x.service.ServiceName,
        //                                  x.RequestDate,
        //                                  x.RequestStatus,
        //                                  x.ResponseStatus,
        //                                  x.AdminResponse.ResponseText ?? "No Response",
        //                                  x.AttachedDocuments.Select(a => a.FileName), /* اعادة الفايل نفسة*/
        //                                  x.Payments.Select(p => p.PaymentStatus)
        //                                  )
        //                                 ).AsNoTracking()
        //                                  .SingleOrDefaultAsync(cancellationToken);



        //    if (request == null)
        //    {
        //        return Result.Falire<RequestDetailsResponse>(ServiceError.ServiceNotFound);
        //    }

        // return Result.Success(request);

        //}

        public async Task<Result<IEnumerable<RequestsDetailstoUser>>> GetUserRequests(CancellationToken cancellationToken)
        {

            var UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);


            var userRequests = await _context.Requests
                                 .Where(x => x.UserId == UserId)
                                 .Select(x => new RequestsDetailstoUser(
                                     x.Id,
                                     x.ServiceId,
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


        public async Task<Result<IEnumerable<RequestsDetailstoUser>>> GetRequestByStatusAsync(string request, CancellationToken cancellationToken)
        {

            var UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var requests = await _context.Requests.Where(r => r.UserId == UserId && r.RequestStatus == request)
                        .Select(x => new RequestsDetailstoUser(
                            x.Id,
                            x.ServiceId,
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
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;


            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var request = new Request
                {
                    RequestDate = DateTime.UtcNow,
                    UserId = userId!,
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
                        var filePath = await fileService.UploadFile(file);
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

        public async Task<Result<IEnumerable<UpdateFields>>> GetUserRequestsDetails(int RequestId, CancellationToken cancellationToken)
        {

            var request = await _context.Requests.FindAsync(RequestId);
            if (request == null)
                return Result.Falire<IEnumerable<UpdateFields>>(RequestErrors.RequestNotFound);

            var Userdata = await _context.ServicesData.Where(x => x.RequestId == RequestId).
                                                        Select(x => new UpdateFields(
                                                            x.FieldId,
                                                            x.Field.FieldName,
                                                            x.Field.HtmlType,
                                                            x.Id,
                                                            x.FieldValueString,
                                                            x.FieldValueInt,
                                                            x.FieldValueFloat,
                                                            x.FieldValueDate,
                                                            x.FieldValueString != null ? "string" :
                                                            x.FieldValueInt != null ? "int" : 
                                                            x.FieldValueFloat != null ? "float" : 
                                                            x.FieldValueDate != null ? "date" : "unknown"

                                                            ))
                                                        .AsNoTracking()
                                                        .ToListAsync(cancellationToken);

            if (!Userdata.Any())
            {

                return Result.Falire<IEnumerable<UpdateFields>>(RequestErrors.NoDataFound);


            }



            return Result.Success<IEnumerable<UpdateFields>>(Userdata);
        }

        public async Task<Result> UpdateRequestAsync(int requestId, IEnumerable<UpdateRequest> requestDto, CancellationToken cancellationToken)
        {
       
            var request = await _context.Requests.FindAsync(requestId);
            if (request == null)
                return Result.Falire<UpdateResponse>(RequestErrors.RequestNotFound);

            foreach (var fieldDto in requestDto)
            {
                var fieldData = await _context.ServicesData.FindAsync(fieldDto.FieldDataId);
                if (fieldData == null)
                    return Result.Falire<UpdateResponse>(RequestErrors.FieldDataNotFound);

                var field = await _context.Fields.FindAsync(fieldDto.FieldId);
                if (field == null)
                    return Result.Falire<UpdateResponse>(RequestErrors.FieldNotFound);

                fieldDto.Adapt(fieldData);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

    }
}


