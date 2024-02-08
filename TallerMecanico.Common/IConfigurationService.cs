using TallerMecanico.Entities.Models;

namespace TallerMecanico.Common
{
    public interface IConfigurationService
    {
        AppSettings GetConfig();
    }
}
