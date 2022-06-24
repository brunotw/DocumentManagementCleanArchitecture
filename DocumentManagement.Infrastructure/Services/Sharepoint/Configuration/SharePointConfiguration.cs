using Microsoft.Extensions.Configuration;

namespace DocumentManagement.Infrastructure.Services.Sharepoint.Configuration
{
    public class SharePointConfiguration : ISharePointConfiguration
    {
        public Uri SiteURL { get; }
        public string Password { get; }
        public string User { get; }
        private readonly IConfiguration _configuration;

        public SharePointConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;

            SiteURL = new Uri(_configuration.GetValue<string>("SharePointConfig:URL"));
            Password = _configuration.GetValue<string>("SharePointConfig:Password");
            User = _configuration.GetValue<string>("SharePointConfig:User");
        }
    }
}
