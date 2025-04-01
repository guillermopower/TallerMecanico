using TallerMecanico.DAL.DesperfectosRepuesto;
using TallerMecanico.DAL.Models;
using TallerMecanico.DAL.Repuesto;

namespace TallerMecanico.Business.Repuesto
{
    public class RepuestoBusiness: IRepuestoBusiness
    {
        private readonly IRepuestoDAL repuestoDAL;
       
        public RepuestoBusiness(IRepuestoDAL repuestoDAL, IDesperfectosRepuestoDAL desperfectoRepuestoDAL)
        {
            this.repuestoDAL = repuestoDAL;
        }

        public void CargarRepuestos(long idRepuesto, long idDefecto)
        {
            repuestoDAL.Add(new DAL.Models.Repuesto()
            {
                Id = idRepuesto,
                DesperfectosRepuestos = new System.Collections.Generic.List<DesperfectosRepuesto>()
                {
                    new DesperfectosRepuesto()
                    {
                        IdDesperfecto = idDefecto,
                        IdRepuesto = idRepuesto
                    }
                }
            });
        }
    }
}
