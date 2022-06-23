using DocumentManagement.Application.DTOs;
using DocumentManagement.Application.Exceptions;
using DocumentManagement.Application.Helpers;
using DocumentManagement.Application.Interfaces.Application;
using DocumentManagement.Application.Interfaces.Infrastructure;
using DocumentManagement.Application.Interfaces.Validators;
using DocumentManagement.Domain.Entities;
using System.Web;

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

        public DownloadDocumentResponseDTO DownloadDocument(string documentPath)
        {
            string documentPathSanatized = HttpUtility.UrlDecode(documentPath);
            return _documentService.DownloadDocument(documentPathSanatized);
        }

        public Document UploadDocument(Document document)
        {
            _documentValidator.ValidateDocument(document);

            Configuration configurationFolderPath = _crmService.GetConfigurationByKey(ConfigurationKeys.SharePoint_FolderPath);

            if (configurationFolderPath == null)
                throw new ConfigurationNotFound(ConfigurationKeys.SharePoint_FolderPath);

            document.FolderPath = configurationFolderPath.Value;

            return _documentService.UploadDocument(document);
        }
    }
}
