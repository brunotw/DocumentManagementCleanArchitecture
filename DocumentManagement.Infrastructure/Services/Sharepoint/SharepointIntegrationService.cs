using DocumentManagement.Application.DTOs;
using DocumentManagement.Application.Interfaces.Infrastructure;
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

        public DownloadDocumentResponse DownloadDocument(string filePath)
        {
            AuthenticationManager authenticationManager = new AuthenticationManager();
            ClientContext context = authenticationManager.GetContext(_sharePointConfiguration.SiteURL, _sharePointConfiguration.User, GetSecurePassword());
            var document = DownloadFile(context, filePath);
            return document;
        }
        public UploadDocumentResponse UploadDocument(UploadDocumentRequest document)
        {
            using (var authenticationManager = new AuthenticationManager())
            {
                using (ClientContext context = authenticationManager.GetContext(_sharePointConfiguration.SiteURL, _sharePointConfiguration.User, GetSecurePassword()))
                {
                    Guid sharepointId = UploadDocument(context, document);

                    return new UploadDocumentResponse
                    {
                        ExternalId = sharepointId.ToString(),
                        Name = document.FileName,
                    };
                }
            }
        }

        private DownloadDocumentResponse DownloadFile(ClientContext context, string fileRef)
        {
            File file = context.Web.GetFileByUrl(fileRef);
            context.Load(file);
            context.ExecuteQuery();

            ClientResult<Stream> fileStream = file.OpenBinaryStream();
            context.ExecuteQuery();

            DownloadDocumentResponse response = new()
            {
                //Id = file.UniqueId,
                FileName = file.Name,
                Stream = fileStream.Value
            };

            return response;
        }
        private Guid UploadDocument(ClientContext context, UploadDocumentRequest document)
        {
            FileCreationInformation fileCreationInfo = new()
            {
                Content = Convert.FromBase64String(document.DocumentBase64),
                Overwrite = true,
                Url = document.FileName
            };

            var targetFolder = context.Web.GetFolderByServerRelativeUrl(document.FolderId);
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
        public DownloadDocumentResponse DownloadDocument(long documentId)
        {
            throw new NotImplementedException();
        }
    }
}
