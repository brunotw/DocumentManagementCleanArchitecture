namespace DocumentManagement.Infrastructure.Services.Sharepoint.Configuration
{
    public interface ISharePointConfiguration
    {
        public Uri SiteURL { get; }
        public string User { get; }
        public string Password { get; }
    }
}
