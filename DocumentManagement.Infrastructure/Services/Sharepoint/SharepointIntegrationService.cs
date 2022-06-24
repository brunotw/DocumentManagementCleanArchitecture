using DocumentManagement.Application.DTOs;
using DocumentManagement.Application.Interfaces.Infrastructure;
using DocumentManagement.Domain.Entities;
using DocumentManagement.Infrastructure.Managers;
using DocumentManagement.Infrastructure.Services.Sharepoint.Configuration;
using Microsoft.SharePoint.Client;
using System.Security;
using File = Microsoft.SharePoint.Client.File;

namespace DocumentManagement.Infrastructure.Services.Sharepoint
{
    public class SharepointIntegrationService : IDocumentService
    {
        private readonly ISharePointConfiguration _sharePointConfiguration;

        public SharepointIntegrationService(ISharePointConfiguration sharePointConfiguration)
        {
            _sharePointConfiguration = sharePointConfiguration;
        }

        public DownloadDocumentResponseDTO DownloadDocument(string filePath)
        {
            AuthenticationManager authenticationManager = new AuthenticationManager();
            ClientContext context = authenticationManager.GetContext(_sharePointConfiguration.SiteURL, _sharePointConfiguration.User, GetSecurePassword());
            var document = DownloadFile(context, filePath);
            return document;
        }
        public Document UploadDocument(Document document)
        {
            using (var authenticationManager = new AuthenticationManager())
            {
                using (ClientContext context = authenticationManager.GetContext(_sharePointConfiguration.SiteURL, _sharePointConfiguration.User, GetSecurePassword()))
                {
                    Guid sharepointId = UploadDocument(context, document);

                    return new Document
                    {
                        Id = sharepointId,
                        FileName = document.FileName,
                    };
                }
            }
        }

        private DownloadDocumentResponseDTO DownloadFile(ClientContext context, string fileRef)
        {
            File file = context.Web.GetFileByUrl(fileRef);
            context.Load(file);
            context.ExecuteQuery();

            ClientResult<Stream> fileStream = file.OpenBinaryStream();
            context.ExecuteQuery();

            DownloadDocumentResponseDTO response = new()
            {
                Id = file.UniqueId,
                FileName = file.Name,
                Stream = fileStream.Value
            };

            return response;
        }
        private Guid UploadDocument(ClientContext context, Document document)
        {
            FileCreationInformation fileCreationInfo = new()
            {
                Content = Convert.FromBase64String(document.DocumentBase64),
                Overwrite = true,
                Url = document.FileName
            };

            var targetFolder = context.Web.GetFolderByServerRelativeUrl(document.FolderPath);
            var uploadFile = targetFolder.Files.Add(fileCreationInfo);
            context.Load(uploadFile);
            context.ExecuteQuery();

            return uploadFile.UniqueId;
        }
        private SecureString GetSecurePassword()
        {
            SecureString securePassword = new();

            foreach (char c in _sharePointConfiguration.Password)
            {
                securePassword.AppendChar(c);
            }

            return securePassword;
        }
    }
}
