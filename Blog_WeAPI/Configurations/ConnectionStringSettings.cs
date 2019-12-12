using LinqToDB.Configuration;

namespace Blog_WeAPI.Configurations
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal { get; set; }

        public ConnectionStringSettings()
        {
            IsGlobal = false;
        }
    }
}
