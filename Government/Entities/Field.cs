namespace Government.Entities
{
    public class Field
    {
        public int FieldID { get; set; }
        public string FiledName { get; set; }
        public string Description { get; set; }


        public ICollection<ServiceData> ServiceData { get; set; }
        public ICollection<Service> Services{ get; set; }
        public ICollection<ServiceField> ServiceFields { get; set; }
    }
}
