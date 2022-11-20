namespace DocumentManagement.Application.DTOs
{
    public class DownloadDocumentResponse
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public string FileExtension
        {
            get { return Path.GetExtension(FileName); }
        }
        public string DocumentBase64 { get; set; }
    }
}
