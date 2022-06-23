namespace DocumentManagement.Application.Exceptions
{
    public class ConfigurationNotFound : Exception
    {
        public ConfigurationNotFound(string key) : base($"Can't find Configuration with key {key}")
        {

        }
    }
}
