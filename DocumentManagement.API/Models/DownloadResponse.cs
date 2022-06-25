namespace DocumentManagement.API.DTOs
{
    public class DownloadResponse
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public Stream Stream { get; set; }
    }
}
