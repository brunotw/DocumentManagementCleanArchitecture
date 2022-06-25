namespace DocumentManagement.API.DTOs
{
    public class UploadRequest
    {
        public string FileName { get; set; }
        public string  DocumentBase64 { get; set; }
    }
}
