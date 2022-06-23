using DocumentManagement.Domain.Entities;

namespace DocumentManagement.Application.Interfaces.Application
{
    public interface ICompassDocumentHandler
    {
        void DownloadDocument(long documentId);
        Task<Document> UploadDocument(Document document);
    }
}
