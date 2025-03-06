namespace Government.Entities
{
    public class Request
    {

        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestStatus { get; set; } 
        public string ResponseStatus { get; set; } 

        public string UserId { get; set; } = string.Empty;
        public int ServiceId { get; set; }

        public AppUser User { get; set; } = default!;
        public Service service { get; set; } = default!;
        public AdminResponse AdminResponse { get; set; } = default!;

        public ICollection<ServiceData> serviceData { get; set; } = [];
        public ICollection<AttachedDocument> AttachedDocuments { get; set; } = [];
        public ICollection<Payment> Payments { get; set; } = [];
   
     

    }
}
