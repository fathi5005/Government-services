namespace Government.Entities
{
    public class RequiredDocument
    {
        public int RequiredDocumentId { get; set; }
        public int ServiceId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

     

        public Service service { get; set; }
    }
}
