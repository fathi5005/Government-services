
namespace Government.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Request> Requests { get; set; }


    }
}
