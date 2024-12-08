namespace Government.Entities
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<AdminResponse> AdminResponses { get; set; }    

    }
}
