using Microsoft.Extensions.Configuration;
using TallerMecanico.Entities.Models;

namespace TallerMecanico.Common
{
    public class ConfigurationService:IConfigurationService
    {
        private readonly IConfiguration configSVC;

        public ConfigurationService(IConfiguration configSVC) { this.configSVC = configSVC; }
        public AppSettings GetConfig()
        {

            AppSettings? settings = configSVC.GetRequiredSection("AppSettings").Get<AppSettings>();
            return new AppSettings()
            {
                ConnectionString = settings.ConnectionString,
                
            };

        }
    }
}
