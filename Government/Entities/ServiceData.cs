namespace Government.Entities
{
    public class ServiceData
    {

        public int Id { get; set; }
        public string? FieldValueString { get; set; }
        public int? FieldValueInt { get; set; }
        public float? FieldValueFloat { get; set; }
        public DateTime? FieldValueDate { get; set; }

        public int RequestId { get; set; }
        public int FieldId { get; set; }
        public Request Request { get; set; } = default!;
        public Field Field { get; set; } = default!;
    

    }
}
