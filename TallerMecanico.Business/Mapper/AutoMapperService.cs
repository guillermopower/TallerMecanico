using AutoMapper;
using TallerMecanico.DAL.Models;
using TallerMecanico.Entities.Models;

namespace TallerMecanico.Business.Mapper
{
    public class AutoMapperService : Profile
    {
        public AutoMapperService()
        {
            CreateMap<TallerMecanico.Entities.Models.Vehiculo, TallerMecanico.DAL.Models.Vehiculo>();
            CreateMap<Automovil, Automovile>();


        }
    }
}
