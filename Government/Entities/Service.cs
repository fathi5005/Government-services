namespace Government.Entities
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }

        public ICollection<Request> Requests { get; set; }  
        public ICollection<RequiredDocument> RequiredDocuments { get; set; }  
        public ICollection<Field> Field { get; set; }
        public ICollection<ServiceField> ServiceFields { get; set; }

     
    }
}
