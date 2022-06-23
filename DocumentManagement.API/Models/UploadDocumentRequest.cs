namespace DocumentManagement.API.DTOs
{
    public class UploadDocumentRequest
    {
        public string FileName { get; set; }
        public string  DocumentBase64 { get; set; }
    }
}
