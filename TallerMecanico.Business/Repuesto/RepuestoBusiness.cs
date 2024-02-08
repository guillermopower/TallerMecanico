using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.DAL.Desperfecto;
using TallerMecanico.DAL.DesperfectosRepuesto;
using TallerMecanico.DAL.Models;
using TallerMecanico.DAL.Repuesto;

namespace TallerMecanico.Business.Repuesto
{
    public class RepuestoBusiness: IRepuestoBusiness
    {
        private readonly IRepuestoDAL repuestoDAL;
        private readonly IDesperfectosRepuestoDAL desperfectoRepuestoDAL;

        public RepuestoBusiness(IRepuestoDAL repuestoDAL, IDesperfectosRepuestoDAL desperfectoRepuestoDAL)
        {
            this.repuestoDAL = repuestoDAL;
            this.desperfectoRepuestoDAL = desperfectoRepuestoDAL;
        }

        public void CargarRepuestos(long idRepuesto, long idDefecto)
        {
            desperfectoRepuestoDAL.Add(new DesperfectosRepuesto()
            {
                IdDesperfecto = idDefecto,
                IdRepuesto = idRepuesto
            });
        }
    }
}
