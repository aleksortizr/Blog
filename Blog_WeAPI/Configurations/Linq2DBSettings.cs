using LinqToDB.Configuration;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Blog_WeAPI.Configurations
{
    public class Linq2DBSettings : ILinqToDBSettings
    {
        private readonly IList<IConnectionStringSettings> connectionStrings;

        private IConfiguration Configuration { get; }
        public IEnumerable<IDataProviderSettings> DataProviders { get; }
        public string DefaultConfiguration { get; }
        public string DefaultDataProvider { get; }
        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                return connectionStrings;
            }
        }

        public Linq2DBSettings(IConfiguration configuration)
        {
            Configuration = configuration;

            connectionStrings = GetDataBaseConnectionStrings();
            DataProviders = Enumerable.Empty<IDataProviderSettings>();

            DefaultConfiguration = connectionStrings[0].Name;
            DefaultDataProvider = connectionStrings[0].ProviderName;
        }

        private IList<IConnectionStringSettings> GetDataBaseConnectionStrings()
        {
            List<IConnectionStringSettings> result = new List<IConnectionStringSettings>();

            result.Add(new ConnectionStringSettings
            {
                Name = Configuration.GetSection("DBSettings").GetValue<string>("Provider"),
                ProviderName = Configuration.GetSection("DBSettings").GetValue<string>("Provider"),
                ConnectionString = Configuration.GetSection("DBSettings").GetValue<string>("ConnectionString"),
            });

            return result;

        }
    }
}
