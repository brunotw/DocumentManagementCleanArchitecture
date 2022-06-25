using DocumentManagement.Application.DTOs;
using DocumentManagement.Application.Interfaces.Validators;
using DocumentManagement.Domain.Entities;

namespace DocumentManagement.Application.Validators
{
    public class DocumentValidator : IDocumentValidator
    {
        public void ValidateDocument(UploadDocumentRequest document)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));

            if (string.IsNullOrEmpty(document.Name))
                throw new ArgumentNullException(nameof(document.Name));

            if (string.IsNullOrEmpty(document.DocumentBase64))
                throw new ArgumentNullException(nameof(document.DocumentBase64));
        }
    }
}
