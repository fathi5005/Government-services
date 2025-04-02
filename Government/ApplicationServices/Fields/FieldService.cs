using Government.Contracts.Documents.cs;
using Government.Contracts.Fields;
using Government.Errors;
using Microsoft.EntityFrameworkCore;

namespace Government.ApplicationServices.Fields
{
    public class FieldService(AppDbContext context) : IFieldService
    {
        private readonly AppDbContext context = context;

   

        public async Task<Result<IEnumerable<FieldsResponse>>> GetFieldAsync(int serviceId, CancellationToken cancellationToken)
        {
            var service = await context.Services.SingleOrDefaultAsync(x => x.Id == serviceId, cancellationToken); // check service id 

            if (service is null)
                return Result.Falire<IEnumerable<FieldsResponse>>(ServiceError.ServiceNotFound);

           var fields = await context.ServicesField
                            .Where(x => x.ServiceId == serviceId)
                            .Select(x=> new FieldsResponse(                  
                                x.Field.Id,
                                x.Field.FieldName,
                                x.Field.Description,
                                x.Field.HtmlType,
                                x.Field.HtmlType == "text" || x.Field.HtmlType == "textarea" ? "string" :
                                x.Field.HtmlType == "number" ? "int" : // افتراض إن number بيبدأ كـ int، الـ frontend هيحدد float لو فيه كسور
                                x.Field.HtmlType == "date" || x.Field.HtmlType == "datetime-local" ? "date" : "unknown"
                                ))
                            .AsNoTracking()
                            .ToListAsync(cancellationToken);

            return Result.Success<IEnumerable<FieldsResponse>>(fields);


        }


        public async Task<Result<IEnumerable<DocumentsResponse>>> GetDocumentsAsync(int serviceId, CancellationToken cancellationToken)
        {
            var service = await context.Services.SingleOrDefaultAsync(x => x.Id == serviceId, cancellationToken); // check service id 

            if (service is null)
                return Result.Falire<IEnumerable<DocumentsResponse>>(ServiceError.ServiceNotFound);

            var Documents = await context.RequiredDocuments
                             .Where(x => x.ServiceId == serviceId)
                             .Select(x => new DocumentsResponse(
                                x.Id,
                                x.FileName,
                                x.Description,
                                x.DocumentType,
                                x.IsMandatory
                                 ))
                             .AsNoTracking()
                             .ToListAsync(cancellationToken);

            return Result.Success<IEnumerable<DocumentsResponse>>(Documents);

        }
    }
}
