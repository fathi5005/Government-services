namespace Government.Contracts.Request.Submiting
{
    public record ServiceDataDto(

         int FieldId,
         string? FieldValueString,
         int? FieldValueInt,
         float? FieldValueFloat,
         DateTime? FieldValueDate
 );

}
