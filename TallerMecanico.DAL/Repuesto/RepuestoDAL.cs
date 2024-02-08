using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.Repuesto
{
    public class RepuestoDAL:IRepuestoDAL
    {
        public long Add(Models.Repuesto repuesto)
        {
            long id = 0;
            using (var context = new TallerMecanicoContext())
            {
                context.Repuestos.Add(repuesto);
                context.SaveChanges();

                id = repuesto.Id;
            }

            return id;
        }

        public long Update(Models.Repuesto repuesto)
        {
            long id = 0;
            using (var context = new TallerMecanicoContext())
            {
                context.Repuestos.Update(repuesto);
                context.SaveChanges();

                id = repuesto.Id;
            }

            return id;
        }

        public Models.Repuesto Get(long id)
        {
            var item = new Models.Repuesto();
            using (var context = new TallerMecanicoContext())
            {
                item = context.Repuestos.FirstOrDefault(x=>x.Id.Equals(id));
            }

            return item;
        }

        public List<Models.Repuesto> GetAll()
        {
            var lista = new List<Models.Repuesto>();
            using (var context = new TallerMecanicoContext())
            {
                lista = context.Repuestos.ToList();
            }

            return lista;
        }
    }
}
