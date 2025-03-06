namespace Government.Entities
{
    public class AttachedDocument
    {
        public int Id { get; set; }
        public int RequestId { get; set; } 
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;  
        public string DocumentType { get; set; } = string.Empty; 
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;  
        public bool IsVerified { get; set; } = false; 

        public Request Request { get; set; } = default!;
    }
}
