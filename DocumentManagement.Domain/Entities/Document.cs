namespace DocumentManagement.Domain.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension
        {
            get
            {
                return string.IsNullOrEmpty(FileName) ? string.Empty : Path.GetExtension(FileName);
            }
        }
        public string DocumentBase64 { get; set; }
        public string FolderPath { get; set; }
    }
}