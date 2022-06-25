using DocumentManagement.Application.DTOs;

namespace DocumentManagement.Application.Interfaces.Validators
{
    public interface IDocumentValidator
    {
        void ValidateDocument(UploadDocumentRequest document);
    }
}
