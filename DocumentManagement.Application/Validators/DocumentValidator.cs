using DocumentManagement.Application.Interfaces.Validators;
using DocumentManagement.Domain.Entities;

namespace DocumentManagement.Application.Validators
{
    public class DocumentValidator : IDocumentValidator
    {
        public void ValidateDocument(Document document)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));

            if (string.IsNullOrEmpty(document.FileName))
                throw new ArgumentNullException(nameof(document.FileName));

            if (string.IsNullOrEmpty(document.DocumentBase64))
                throw new ArgumentNullException(nameof(document.DocumentBase64));
        }
    }
}
