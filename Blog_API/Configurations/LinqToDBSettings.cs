using System.Collections.Generic;
using System.Linq;
using LinqToDB.Configuration;


namespace Blog_API.Configurations
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;


    }

    public class LinqToDbSettingsDevelopment : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "SqlServer";
        public string DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "SqlServer",
                        ProviderName = "SqlServer",
                        //ConnectionString = @"Server=DESKTOP-94C82G3;Database=Blog;Trusted_Connection=True;" //Alexander Home
                        ConnectionString = @"Server=DESKTOP-8FG06S6;Database=Blog;Trusted_Connection=True;" //Alexander office
                    };
            }
        }
    }
}
