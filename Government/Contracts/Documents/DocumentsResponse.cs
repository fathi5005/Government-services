using Government.Contracts.Documents.cs;

namespace Government.Contracts.Documents.cs
{
    public record DocumentsResponse
    (
       int Id,
       string FiledName,
       string Description,
       string DocumentType,
       bool IsMandatory

    );
}
