namespace DocumentManagement.API.DTOs
{
    public class DownloadResponse
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string DocumentBase64 { get; set; }
    }
}
