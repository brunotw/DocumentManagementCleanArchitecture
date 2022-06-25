using DocumentManagement.Application.DTOs;

namespace DocumentManagement.Application.Interfaces.Application
{
    public interface IDocumentHandler
    {
        UploadDocumentResponse UploadDocument(UploadDocumentRequest document);
        DownloadDocumentResponse DownloadDocument(string fileName);
    }
}
