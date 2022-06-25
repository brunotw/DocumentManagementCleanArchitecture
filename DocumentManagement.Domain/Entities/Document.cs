namespace DocumentManagement.Domain.Entities
{
    public class Document
    {
        public Guid CRMId { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
    }
}