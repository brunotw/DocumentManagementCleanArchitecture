using DocumentManagement.Application.DTOs;

namespace DocumentManagement.Application.Interfaces.Application
{
    public interface IDocumentHandler
    {
        UploadDocumentResponse UploadDocument(UploadDocumentRequest document);
        DownloadDocumentResponse DownloadDocument(long documentId);
        void DeleteDocument(long documentId);
    }
}
