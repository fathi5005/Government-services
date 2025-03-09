namespace Government.Entities
{
    public class Field
    {
        public int Id { get; set; }
        public string FieldName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string HtmlType { get; set; } = string.Empty;

        public ICollection<ServiceData> ServiceData { get; set; } = [];
        public ICollection<Service> Services { get; set; } = [];
        public ICollection<ServiceField> ServiceFields { get; set; } = [];
    }
}
