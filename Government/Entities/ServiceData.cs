namespace Government.Entities
{
    public class ServiceData
    {

        public int ServiceDataID { get; set; }
        public int RequestId { get; set; }
        public int FieldID { get; set; }
        public string? FieldValueString { get; set; }
        public int? FieldValueInt { get; set; }
        public float? FieldValueFloat { get; set; }
        public DateTime? FieldValueDate { get; set; }

        public Request Request { get; set; }

        public Field Field { get; set; }
    

    }
}
