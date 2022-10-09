namespace DocumentManagement.Application.DTOs
{
    public  class UploadDocumentRequest
    {
        public string FileName { get; set; }
        public string DocumentBase64 { get; set; }
        public string FolderId{ get; set; }
    }
}
