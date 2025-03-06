namespace Government.Entities
{
    public class AppUser : IdentityUser
    {
       
        public string FirstName { get; set; }= string.Empty;
        public string LastName { get; set; } = string.Empty;


        public ICollection<AdminResponse> AdminResponses { get; set; } = [];

    }
}
