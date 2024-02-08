using AutoMapper;

namespace TallerMecanico.Business.Mapper
{
    public class AutoMapperConfiguration
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperService>();
            });
            return config;
        }
    }
}
