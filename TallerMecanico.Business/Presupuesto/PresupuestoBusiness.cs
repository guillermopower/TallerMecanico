using AutoMapper;
using TallerMecanico.DAL.DescuentosRecargos;
using TallerMecanico.DAL.Desperfecto;
using TallerMecanico.DAL.DesperfectosRepuesto;
using TallerMecanico.DAL.Models;
using TallerMecanico.DAL.Presupuesto;
using TallerMecanico.DAL.Repuesto;

namespace TallerMecanico.Business.Presupuesto
{
    public class PresupuestoBusiness: IPresupuestoBusiness
    {
        private readonly IPresupuestoDAL presupuestoDAL;
        private readonly IDescuentosRecargosDAL descuentosRecargosDAL;
        private readonly IDesperfectosRepuestoDAL desperfectosRepuestoDAL;
        private readonly IRepuestoDAL repuestoDAL;
        private readonly IDesperfectoDAL desperfectoDAL;
        public PresupuestoBusiness(IPresupuestoDAL presupuestoDAL, IDescuentosRecargosDAL descuentosRecargosDAL,
            IRepuestoDAL repuestoDAL, IDesperfectoDAL desperfectoDAL, IDesperfectosRepuestoDAL desperfectosRepuestoDAL)
        {
            this.presupuestoDAL = presupuestoDAL;
            this.descuentosRecargosDAL = descuentosRecargosDAL;
            this.repuestoDAL= repuestoDAL;
            this.desperfectoDAL = desperfectoDAL;
            this.desperfectosRepuestoDAL = desperfectosRepuestoDAL;
        }

        public async Task<decimal?> CalcularTotal(long idPresupuesto)
        {
            decimal? total = 0;
            decimal? manoDeObra = 0;
            decimal? repuestos = 0;

            var listaDesperfectos = desperfectoDAL.GetByPresupuestoId(idPresupuesto);
            listaDesperfectos.ForEach(x => {
                manoDeObra += x.ManoDeObra;
                var listaRepuestos = desperfectosRepuestoDAL.GetMany(x.Id);
            });

            var ListaDetalleDesperfectos = desperfectosRepuestoDAL.GetMany(idPresupuesto);
            ListaDetalleDesperfectos.ForEach(x => {
                repuestos += repuestoDAL.Get(x.IdRepuesto).Precio;
                
            });

            total = + manoDeObra + repuestos;

            var descuentos = descuentosRecargosDAL.GetAll(true);


            descuentos.ForEach(x =>
            {
                if (x.EsValorAbsoluto) total += x.ValorAbsoluto;
                else total += ((decimal)(total) * (x.ValorPorcentual / 100));
            });

            return total;
        }

        public async Task<long> AddOrUpdate(TallerMecanico.Entities.Models.Presupuesto model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entities.Models.Presupuesto, DAL.Models.Presupuesto>());
            var _mapper = config.CreateMapper();
            var presupuesto = _mapper.Map<DAL.Models.Presupuesto>(model);

            presupuesto.Total = (decimal) await CalcularTotal(presupuesto.Id);
            var res = await presupuestoDAL.AddOrUpdate(presupuesto);
            return res;
        }

        public async Task<DAL.Models.Presupuesto> Get(long idPresupuesto)
        {
            DAL.Models.Presupuesto item = new DAL.Models.Presupuesto();
            item = await presupuestoDAL.Get(idPresupuesto);
            return item;

        }
    }
}
