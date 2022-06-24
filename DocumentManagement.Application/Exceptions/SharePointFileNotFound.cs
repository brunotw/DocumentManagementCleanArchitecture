namespace DocumentManagement.Application.Exceptions
{
    public class SharePointFileNotFound : Exception
    {
        public SharePointFileNotFound(string key) : base($"File {key} not found")
        {

        }
    }
}
