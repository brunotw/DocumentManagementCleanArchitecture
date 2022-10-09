namespace DocumentManagement.Application.DTOs
{
    public class DownloadDocumentResponse
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public Stream Stream { get; set; }
    }
}
