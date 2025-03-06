namespace Government.Entities
{
    public class AdminResponse
    {

        public int Id { get; set; }
        public string ResponseText { get; set; }  = string.Empty;
        public DateTime ResponseDate { get; set; }
        public int RequestId { get; set; }
        public string userId { get; set; } = string.Empty ;
        public AppUser user { get; set; } = default!;
        public Request Request { get; set; } = default !;

    }
}
