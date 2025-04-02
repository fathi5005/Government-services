namespace Government.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string ServiceDescription { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = false;
        public decimal Fee { get; set; }
        public string ProcessingTime { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;

        public ICollection<Request> Requests { get; set; } = [];
        public ICollection<RequiredDocument> RequiredDocuments { get; set; } = [];
        public ICollection<Field> Field { get; set; } = [];
        public ICollection<ServiceField> ServiceFields { get; set; } = [];

     
    }
}
