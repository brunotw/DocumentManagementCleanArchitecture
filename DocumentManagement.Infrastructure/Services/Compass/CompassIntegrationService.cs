using DocumentManagement.Application.DTOs;
using DocumentManagement.Application.Interfaces.Infrastructure;

namespace DocumentManagement.Infrastructure.Services.Compass
{
    public class CompassIntegrationService : IDocumentService
    {
        private static readonly List<DownloadDocumentResponse> downloadDocumentResponses = new List<DownloadDocumentResponse>();
        public UploadDocumentResponse UploadDocument(UploadDocumentRequest document)
        {
            DownloadDocumentResponse doc = new DownloadDocumentResponse()
            {
                FileName = document.FileName,
                Stream = new MemoryStream(Convert.FromBase64String(document.DocumentBase64)),
                Id = DateTime.Now.Ticks
            };

            downloadDocumentResponses.Add(doc);

            return new UploadDocumentResponse()
            {
                Name = doc.FileName,
                ExternalId = doc.Id.ToString()
            };
        }
        public DownloadDocumentResponse DownloadDocument(long documentId)
        {
            var document = downloadDocumentResponses.Where(d => d.Id == documentId).FirstOrDefault();
            return document;
        }

        public void DeleteDocument(long documentId)
        {
            var document = downloadDocumentResponses.Where(d => d.Id == documentId).FirstOrDefault();

            if (document == null)
                throw new Exception($"Document with id {documentId} not found");

            downloadDocumentResponses.Remove(document);
        }
    }
}
