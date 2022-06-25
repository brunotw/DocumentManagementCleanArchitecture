namespace DocumentManagement.Application.DTOs
{
    public  class UploadDocumentRequest
    {
        public string Name { get; set; }
        public string DocumentBase64 { get; set; }
        public string FolderPath{ get; set; }
    }
}
