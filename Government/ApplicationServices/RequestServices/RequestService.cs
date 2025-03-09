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
          
            var docsFolder = Path.Combine(env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "upload");

            Directory.CreateDirectory(docsFolder);

            var fileCount = Directory.GetFiles(docsFolder).Length + 1;

            var fileName = $"{fileCount}_{file.FileName}";
            var filePath = Path.Combine(docsFolder, fileName);

           
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"https://government-services.runasp.net/docs/{fileName}";
        }

    }
}

/*
 <form id="submitRequestForm">
  <label for="userId">معرف المستخدم:</label>
  <input type="text" id="userId" name="UserId" value="user123" />
  <br />

  <label for="serviceId">معرف الخدمة:</label>
  <input type="number" id="serviceId" name="ServiceId" value="2" onchange="loadFields()" />
  <br />

  <!-- حيث سيتم إضافة الحقول ديناميكيًا -->
  <div id="dynamicFields"></div>

  <label for="files">الملفات:</label>
  <input type="file" id="files" name="Files" multiple />
  <br />

  <button type="submit">إرسال الطلب</button>
</form>

<script>
// جلب تعريف الحقول بناءً على ServiceId
function loadFields() {
    const serviceId = document.getElementById('serviceId').value;
    fetch(`https://government-services.runasp.net/api/services/${serviceId}/fields`)
        .then(response => response.json())
        .then(fields => {
            const container = document.getElementById('dynamicFields');
            container.innerHTML = ''; // مسح الحقول السابقة

            fields.forEach(field => {
                const label = document.createElement('label');
                label.textContent = `${field.Name}: `;

                const input = document.createElement('input');
                input.dataset.fieldId = field.FieldId; // تخزين FieldId
                input.dataset.fieldType = field.Type;  // تخزين نوع الحقل

                // تحديد نوع الـ input بناءً على Type
                if (field.Type === 'date') input.type = 'date';
                else if (field.Type === 'int' || field.Type === 'float') input.type = 'number';
                else input.type = 'text'; // string افتراضيًا

                container.appendChild(label);
                container.appendChild(input);
                container.appendChild(document.createElement('br'));
            });
        })
        .catch(error => alert('خطأ في جلب الحقول: ' + error));
}

// إرسال الطلب
document.getElementById('submitRequestForm').addEventListener('submit', function(e) {
    e.preventDefault();

    const userId = document.getElementById('userId').value;
    const serviceId = document.getElementById('serviceId').value;
    const files = document.getElementById('files').files;

    // جمع بيانات الحقول ديناميكيًا
    const inputs = document.querySelectorAll('#dynamicFields input');
    const serviceData = Array.from(inputs).map(input => {
        const fieldId = parseInt(input.dataset.fieldId);
        const fieldType = input.dataset.fieldType;
        const value = input.value;

        // وضع القيمة في المتغير الصحيح بناءً على نوع الحقل
        let data = { FieldId: fieldId };
        if (fieldType === 'string') {
            data.FieldValueString = value || null;
            data.FieldValueInt = null;
            data.FieldValueFloat = null;
            data.FieldValueDate = null;
        } else if (fieldType === 'int') {
            data.FieldValueString = null;
            data.FieldValueInt = value ? parseInt(value) : null;
            data.FieldValueFloat = null;
            data.FieldValueDate = null;
        } else if (fieldType === 'float') {
            data.FieldValueString = null;
            data.FieldValueInt = null;
            data.FieldValueFloat = value ? parseFloat(value) : null;
            data.FieldValueDate = null;
        } else if (fieldType === 'date') {
            data.FieldValueString = null;
            data.FieldValueInt = null;
            data.FieldValueFloat = null;
            data.FieldValueDate = value ? new Date(value).toISOString() : null;
        }

        return data;
    });

    // إنشاء FormData
    const formData = new FormData();
    formData.append('UserId', userId);
    formData.append('ServiceId', serviceId);

    // إضافة الملفات
    for (let i = 0; i < files.length; i++) {
        formData.append('Files', files[i]);
    }

    // إضافة ServiceData كـ JSON
    formData.append('ServiceData', JSON.stringify(serviceData));

    // إرسال الطلب
    fetch('https://government-services.runasp.net/api/submit-request', {
        method: 'POST',
        body: formData
    })
    .then(response => response.json())
    .then(data => alert('تم الإرسال بنجاح: ' + JSON.stringify(data)))
    .catch(error => alert('خطأ في الإرسال: ' + error));
});

// تحميل الحقول عند تحميل الصفحة
loadFields();
</script>
 
 */