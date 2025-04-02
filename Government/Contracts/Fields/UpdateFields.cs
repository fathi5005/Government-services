using Government.Contracts.Request.Submiting;

namespace Government.Contracts.Fields
{
    public record UpdateFields
    (
       int FieldId,
       string FiledName,
       string HtmlType,
       int FieldDataId,
       string? FieldValueString,
       int? FieldValueInt,
       float? FieldValueFloat,
       DateTime? FieldValueDate,
       string ValueType


    );

}
