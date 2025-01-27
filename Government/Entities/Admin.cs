namespace Government.Entities
{
    public class Admin : IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
     

        public ICollection<AdminResponse> AdminResponses { get; set; }    

    }
}
