namespace Government.Entities
{
    public class Request
    {

        public int RequestID { get; set; }
        public int ServiceId { get; set; }
        public string UserId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestStatus { get; set; }
        public string ResponseStatus { get; set; }
        public ApplicationUser User { get; set; }
        public Service service { get; set; }
        public AdminResponse AdminResponse { get; set; }
        public ICollection<ServiceData>  serviceData { get; set; }
        public ICollection<AttachedDocument> AttachedDocuments { get; set; }
        public ICollection<Payment> Payments { get; set; }
   
     

    }
}
