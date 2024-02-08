using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.Vehiculo
{
    public class VehiculoDAL:IVehiculoDAL
    {
        public List<Models.Vehiculo> GetVehiculosADiagnosticar()
        {
            var lista = new List<Models.Vehiculo>();
            using (var context = new TallerMecanicoContext())
            {
                lista = context.Vehiculos.Where(x => context.Presupuestos.All(y => y.IdVehiculo != x.Id)).OrderBy(z=>z.FechaIngreso).ToList();
                return lista;
            }
        }
    }
}
