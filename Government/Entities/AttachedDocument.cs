namespace Government.Entities
{
    public class AttachedDocument
    {
        public int AttachedDocumentID { get; set; }
        public int RequestId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Request Request { get; set; }
    }
}
