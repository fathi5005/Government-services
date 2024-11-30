namespace Government.Entities
{
    public class ServiceField
    {

        public int FieldID { get; set; }
        public int ServiceID { get; set; }

        public Service service { get; set; }
        public Field Field { get; set; }
    }
}
