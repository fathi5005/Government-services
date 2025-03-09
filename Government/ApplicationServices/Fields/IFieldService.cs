using Government.Contracts.Documents.cs;
using Government.Contracts.Fields;

namespace Government.ApplicationServices.Fields
{
    public interface IFieldService
    {

        Task<Result <IEnumerable<FieldsResponse>>> GetFieldAsync(int serviceId , CancellationToken cancellationToken);
        Task<Result <IEnumerable<DocumentsResponse>>> GetDocumentsAsync(int serviceId , CancellationToken cancellationToken);
    }
}
