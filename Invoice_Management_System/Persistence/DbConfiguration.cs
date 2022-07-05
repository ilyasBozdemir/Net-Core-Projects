
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence
{
    public class DbConfiguration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();

                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                  "../../../Infrastructure/Presentation/Web.App"));

                
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("SQLSERVER");

            }
        }
    }
}
