using AutoMapper;
using TallerMecanico.DAL.Automovil;
using TallerMecanico.DAL.Models;
using TallerMecanico.DAL.Moto;
using TallerMecanico.DAL.Vehiculo;
using TallerMecanico.Entities.DataTransferObjects;

namespace TallerMecanico.Business.Vehiculos
{
    public class VehiculoBusiness:IVehiculoBusiness
    {
        private readonly IAutomovilDAL automovilDAL;
        private readonly IMotoDAL motoDAL;
        private readonly IVehiculoDAL vehiculoDAL;
        public VehiculoBusiness(IAutomovilDAL automovilDAL, IMotoDAL motoDAL, IVehiculoDAL vehiculoDAL)
        {
            this.automovilDAL = automovilDAL;
            this.motoDAL = motoDAL;
            this.vehiculoDAL = vehiculoDAL;
        }

        public async Task<long> Ingresar(VehiculoDTO model)
        {
            long id = 0;
            var vehiculo = new DAL.Models.Vehiculo() { Marca = model.Marca, Modelo = model.Modelo, Patente = model.Patente, FechaIngreso = DateTime.Now };
            if (model.EsMoto)
            {
                var moto = new DAL.Models.Moto()
                {
                    Cilindrada = model.Cilindrada,
                    IdVehiculoNavigation = vehiculo
                };
                id = motoDAL.SaveOrUpdate(moto);
            }
            else
            {
                var auto = new DAL.Models.Automovile()
                {
                    Tipo = model.Tipo,
                    CantidadPuertas = model.CantidadPuertas,
                    IdVehiculoNavigation = vehiculo
                };
                id = automovilDAL.SaveOrUpdate(auto);
            }

            return id;
        }

        public async Task<List<Vehiculo>> GetVehiculosADiagnosticar()
        {
           return vehiculoDAL.GetVehiculosADiagnosticar();

        }

    }
}
