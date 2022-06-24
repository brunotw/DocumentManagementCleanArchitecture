using DocumentManagement.Application.DTOs;
using DocumentManagement.Domain.Entities;

namespace DocumentManagement.Application.Interfaces.Application
{
    public interface IDocumentHandler
    {
        Document UploadDocument(Document document);
        DownloadDocumentResponseDTO DownloadDocument(string fileName);
    }
}
