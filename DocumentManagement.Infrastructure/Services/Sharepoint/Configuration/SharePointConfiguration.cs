namespace DocumentManagement.Infrastructure.Services.Sharepoint.Configuration
{
    public class SharePointConfiguration : ISharePointConfiguration
    {
        public Uri SiteURL { get; } = new Uri("https://brunotwdev.sharepoint.com/sites/brunotw");
        public string Password { get; } = "O3eikpxf!";
        public string User { get; } = "brunotw@brunotwdev.onmicrosoft.com";
    }
}
