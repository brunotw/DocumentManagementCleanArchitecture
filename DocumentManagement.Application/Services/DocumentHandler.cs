using DocumentManagement.Application.DTOs;
using DocumentManagement.Application.Exceptions;
using DocumentManagement.Application.Helpers;
using DocumentManagement.Application.Interfaces.Application;
using DocumentManagement.Application.Interfaces.Infrastructure;
using DocumentManagement.Application.Interfaces.Validators;
using DocumentManagement.Domain.Entities;

namespace DocumentManagement.Application.Services
{
    public class DocumentHandler : IDocumentHandler
    {
        private readonly IDocumentService _documentService;
        private readonly IDocumentValidator _documentValidator;
        private readonly ICRMService _crmService;

        public DocumentHandler(IDocumentService documentService, IDocumentValidator documentValidator, ICRMService crmService)
        {
            _documentService = documentService;
            _documentValidator = documentValidator;
            _crmService = crmService;
        }

        public UploadDocumentResponse UploadDocument(UploadDocumentRequest document)
        {
            _documentValidator.ValidateDocument(document);

            Configuration compassFolderId = _crmService.GetConfigurationByKey(ConfigurationKeys.Compass_FolderId);

            if (compassFolderId == null)
                throw new ConfigurationNotFound(ConfigurationKeys.Compass_FolderId);

            document.FolderId = compassFolderId.Value;

            return _documentService.UploadDocument(document);
        }

        public DownloadDocumentResponse DownloadDocument(long documentId)
        {
            var document = _documentService.DownloadDocument(documentId);

            if (document == null) throw new Exception($"Document with id {documentId} not found.");

            return document;
        }

        public void DeleteDocument(long documentId)
        {
            _documentService.DeleteDocument(documentId);
        }
    }
}
