using DocumentManagement.Application.DTOs;

namespace DocumentManagement.Application.Interfaces.Infrastructure
{
    public interface IDocumentService
    {
        UploadDocumentResponse UploadDocument(UploadDocumentRequest document);
        DownloadDocumentResponse DownloadDocument(long documentId);
        void DeleteDocument(long documentId);  
    }
}
