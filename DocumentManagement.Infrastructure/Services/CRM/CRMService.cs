using DocumentManagement.Application.Interfaces.Infrastructure;
using DocumentManagement.Domain.Entities;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Extensions.Configuration;
using Microsoft.Xrm.Sdk.Query;

namespace DocumentManagement.Infrastructure.Services.CRM
{
    public class CRMService : ICRMService
    {
        private readonly IConfiguration _configuration;
        private readonly IOrganizationService _service;

        private readonly string clientId;
        private readonly string clientSecret;
        private readonly string environment;

        public CRMService(IConfiguration config)
        {
            _configuration = config;
            clientId = _configuration.GetValue<string>("CRMConfig:ClientId");
            clientSecret = _configuration.GetValue<string>("CRMConfig:ClientSecret");
            environment = _configuration.GetValue<string>("CRMConfig:Environment");
            _service = ConnectToCRM();
        }

        public Configuration GetConfigurationByKey(string key)
        {
            string query = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                <entity name='bw_configuration'>
                                    <attribute name='bw_configurationid'/>
                                    <attribute name='bw_name' />
                                    <attribute name='bw_value' />
                                    <filter type='and'>
                                        <condition attribute='bw_name' operator='eq' value='" + key + @"' />
                                        <condition attribute='statecode' operator='eq' value='0' />
                                        <condition attribute='bw_value' operator='not-null' />
                                    </filter>
                                </entity>
                             </fetch>";

            Entity configuraitonEntity = _service.RetrieveMultiple(new FetchExpression(query)).Entities.FirstOrDefault();

            if (configuraitonEntity != null)
            {
                Configuration configuration = new Configuration()
                {
                    Id = configuraitonEntity.Id,
                    Key = configuraitonEntity.GetAttributeValue<string>("bw_name"),
                    Value = configuraitonEntity.GetAttributeValue<string>("bw_value")
                };

                return configuration;
            }

            return null;
        }

        private IOrganizationService ConnectToCRM()
        {
            var connectionString = @$"Url=https://{environment}.dynamics.com;AuthType=ClientSecret;ClientId={clientId};ClientSecret={clientSecret};RequireNewInstance=true";
            ServiceClient organizationService = new ServiceClient(connectionString);

            if (organizationService.IsReady == false)
                throw new Exception($"Error while trying to connect to CRM. Error details: {organizationService.LastError}");

            return organizationService;
        }
    }
}
