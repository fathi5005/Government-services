namespace Government.Entities

{
    public class ApplicationUser :IdentityUser
    {
      
        public string Name { get; set; }
        public string NationalId { get; set; }
     
        public string PhoneNumber { get; set; }
     

        public ICollection<Request> Requests { get; set; }


    }
}
