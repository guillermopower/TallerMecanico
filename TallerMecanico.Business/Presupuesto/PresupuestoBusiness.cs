using AutoMapper;
using TallerMecanico.DAL.DescuentosRecargos;
using TallerMecanico.DAL.Desperfecto;
using TallerMecanico.DAL.DesperfectosRepuesto;
using TallerMecanico.DAL.Models;
using TallerMecanico.DAL.Presupuesto;
using TallerMecanico.DAL.Repuesto;

namespace TallerMecanico.Business.Presupuesto
{
    public class PresupuestoBusiness : IPresupuestoBusiness
    {
        private readonly IPresupuestoDAL _presupuestoDAL;
        private readonly IDescuentosRecargosDAL _descuentosRecargosDAL;
        private readonly IDesperfectosRepuestoDAL _desperfectosRepuestoDAL;
        private readonly IRepuestoDAL _repuestoDAL;
        private readonly IDesperfectoDAL _desperfectoDAL;

        public PresupuestoBusiness(IPresupuestoDAL presupuestoDAL, IDescuentosRecargosDAL descuentosRecargosDAL,
            IRepuestoDAL repuestoDAL, IDesperfectoDAL desperfectoDAL, IDesperfectosRepuestoDAL desperfectosRepuestoDAL)
        {
            _presupuestoDAL = presupuestoDAL;
            _descuentosRecargosDAL = descuentosRecargosDAL;
            _repuestoDAL = repuestoDAL;
            _desperfectoDAL = desperfectoDAL;
            _desperfectosRepuestoDAL = desperfectosRepuestoDAL;
        }

        public async Task<decimal?> CalcularTotal(long idPresupuesto)
        {
            decimal manoDeObra = 0;
            decimal repuestos = 0;

            var listaDesperfectos = await _desperfectoDAL.GetByPresupuestoId(idPresupuesto);
            foreach (var desperfecto in listaDesperfectos)
            {
                manoDeObra += desperfecto.ManoDeObra ?? 0;
                var listaRepuestos = await _desperfectosRepuestoDAL.GetMany(desperfecto.Id);
                foreach (var repuesto in listaRepuestos)
                {
                    repuestos += (await _repuestoDAL.Get(repuesto.IdRepuesto)).Precio ?? 0;
                }
            }

            decimal total = manoDeObra + repuestos;

            var descuentos = await _descuentosRecargosDAL.GetAll();
            foreach (var descuento in descuentos)
            {
                if (descuento.EsValorAbsoluto)
                {
                    total += descuento.ValorAbsoluto ?? 0;
                }
                else
                {
                    total += total * (descuento.ValorPorcentual ?? 0) / 100;
                }
            }

            return total;
        }

        public async Task<long> AddOrUpdate(TallerMecanico.Entities.Models.Presupuesto model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entities.Models.Presupuesto, DAL.Models.Presupuesto>());
            var mapper = config.CreateMapper();
            var presupuesto = mapper.Map<DAL.Models.Presupuesto>(model);

            presupuesto.Total = await CalcularTotal(presupuesto.Id) ?? 0;
            return await _presupuestoDAL.AddOrUpdate(presupuesto);
        }

        public async Task<DAL.Models.Presupuesto> Get(long idPresupuesto)
        {
            return await _presupuestoDAL.Get(idPresupuesto);
        }
    }
}
