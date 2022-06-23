using DocumentManagement.Domain.Entities;

namespace DocumentManagement.Application.Interfaces.Infrastructure
{
    public interface ICRMService
    {
        Configuration GetConfigurationByKey(string key);
    }
}
