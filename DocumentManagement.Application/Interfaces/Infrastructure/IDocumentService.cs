using DocumentManagement.Application.DTOs;
using DocumentManagement.Domain.Entities;

namespace DocumentManagement.Application.Interfaces.Infrastructure
{
    public interface IDocumentService
    {
        Document UploadDocument(Document document);
        DownloadDocumentResponseDTO DownloadDocument(string filePath);
    }
}
