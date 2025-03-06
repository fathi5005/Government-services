namespace Government.Entities
{
    public class ServiceField
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public int ServiceId { get; set; }

        public Service service { get; set; } = default!;
        public Field Field { get; set; } = default!;
    }
}
