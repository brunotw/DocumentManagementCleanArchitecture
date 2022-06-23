using DocumentManagement.Domain.Entities;

namespace DocumentManagement.Application.Interfaces.Validators
{
    public interface IDocumentValidator
    {
        void ValidateDocument(Document document);
    }
}
