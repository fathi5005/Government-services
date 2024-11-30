namespace Government.Entities
{
    public class AdminResponse
    {

        public int AdminResponseId { get; set; }
        public int RequestId { get; set; }
        public int AdminId { get; set; }

        public string ResponseText { get; set; }
        public DateTime ResponseDate { get; set; }

       
        public Admin Admin { get; set; }
        public Request Request { get; set; }

    }
}
