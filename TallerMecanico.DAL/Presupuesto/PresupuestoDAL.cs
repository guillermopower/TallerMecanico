using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.Presupuesto
{
    public class PresupuestoDAL: IPresupuestoDAL
    {
        public async Task<long> AddOrUpdate(Models.Presupuesto presupuesto)
        {
            long id = 0;
            using (var context = new TallerMecanicoContext())
            {
                if(presupuesto.Id==0)
                    context.Presupuestos.Add(presupuesto);
                else
                    context.Presupuestos.Update(presupuesto);
                context.SaveChanges();

                id = presupuesto.Id;
            }

            return id;
        }

        public async Task<DAL.Models.Presupuesto> Get(long idPresupuesto)
        {
            var item = new Models.Presupuesto();
            using (var context = new TallerMecanicoContext())
            {
                item = context.Presupuestos.FirstOrDefault(x => x.Id.Equals(idPresupuesto));
            }

            return item;
        }
    }
}
