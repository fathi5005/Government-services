namespace Government.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public int RequestId { get; set; }
        public Request Request { get; set; }

    }
}
