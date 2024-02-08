using TallerMecanico.Entities.DataTransferObjects;
using TallerMecanico.DAL.Models;

namespace TallerMecanico.Business.Vehiculos
{
    public interface IVehiculoBusiness
    {
        public Task<long> Ingresar(VehiculoDTO model);
        public Task<List<Vehiculo>> GetVehiculosADiagnosticar();
    }
}
