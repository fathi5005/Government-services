namespace Government.Contracts.Request.Submiting
{
    public record ServiceDataDto(
         // لكل فيلد قيمة واحدة فقط
         int FieldId,
         string? FieldValueString,
         int? FieldValueInt,
         float? FieldValueFloat,
         DateTime? FieldValueDate
 );

}
