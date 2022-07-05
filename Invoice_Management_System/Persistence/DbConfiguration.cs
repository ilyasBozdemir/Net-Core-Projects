
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence
{
    public class DbConfiguration
    {
        public static string activeWebProjectName 
        { get; set; } = "Web.App";
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();

                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                  $"../{activeWebProjectName}"));

                
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("SQLSERVER");

            }
        }
    }
}
