namespace Government.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int RequestId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }

        public Request Request { get; set; }

    }
}
