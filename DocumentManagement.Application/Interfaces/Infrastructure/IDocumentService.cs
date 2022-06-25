using DocumentManagement.Application.DTOs;

namespace DocumentManagement.Application.Interfaces.Infrastructure
{
    public interface IDocumentService
    {
        UploadDocumentResponse UploadDocument(UploadDocumentRequest document);
        DownloadDocumentResponse DownloadDocument(string filePath);
    }
}
