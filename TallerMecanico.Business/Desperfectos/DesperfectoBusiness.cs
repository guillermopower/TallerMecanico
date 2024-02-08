using TallerMecanico.DAL.Desperfecto;
using TallerMecanico.DAL.Presupuesto;

namespace TallerMecanico.Business.Desperfectos
{
    public class DesperfectoBusiness:IDesperfectoBusiness
    {
        private readonly IDesperfectoDAL desperfectoDAL;
        private readonly IPresupuestoDAL presupuestoDAL; 

        public DesperfectoBusiness(IDesperfectoDAL desperfectoDAL, IPresupuestoDAL presupuestoDAL)
        {
            this.desperfectoDAL = desperfectoDAL;
            this.presupuestoDAL = presupuestoDAL;
        }

        public bool CargarDefectos(long idPresupuesto, List<TallerMecanico.Entities.Models.Desperfecto> desperfectos)
        {
            bool res = false;
            try
            {
                var ppto = presupuestoDAL.Get(idPresupuesto);

                var _desperfectos = new List<TallerMecanico.DAL.Models.Desperfecto>();
                desperfectos.ForEach(x => {
                    _desperfectos.Add(new DAL.Models.Desperfecto()
                    {
                        Descripcion = x.Descripcion,
                        ManoDeObra = (decimal)x.ManoDeObra,
                        Tiempo = x.Tiempo,
                        IdPresupuesto = ppto.Id,
                        Id = x.Id,

                    });

                });
                _desperfectos.ForEach(x => {
                    x.IdPresupuesto = idPresupuesto;
                    desperfectoDAL.Add(x);
                });

                res = true;
            }
            catch{}
            return res;
        }
    }
}
