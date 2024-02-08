using TallerMecanico.DAL.DesperfectosRepuesto;
using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.DesperfectosRepuestosRepuesto
{
    public class DesperfectosRepuestoDAL: IDesperfectosRepuestoDAL
    {
        public long Add(Models.DesperfectosRepuesto desperfectosRepuesto)
        {
            long id = 0;
            using (var context = new TallerMecanicoContext())
            {
                context.DesperfectosRepuestos.Add(desperfectosRepuesto);
                context.SaveChanges();

                id = desperfectosRepuesto.Id;
            }

            return id;
        }

        public long Update(Models.DesperfectosRepuesto desperfectosRepuesto)
        {
            long id = 0;
            using (var context = new TallerMecanicoContext())
            {
                context.DesperfectosRepuestos.Update(desperfectosRepuesto);
                context.SaveChanges();

                id = desperfectosRepuesto.Id;
            }

            return id;
        }

        public List<Models.DesperfectosRepuesto> GetMany(long idDesperfecto)
        {
            var lista = new List<Models.DesperfectosRepuesto>();
            using (var context = new TallerMecanicoContext())
            {
                lista = context.DesperfectosRepuestos.Where(x=>x.IdDesperfecto.Equals(idDesperfecto)).ToList();
            }

            return lista;
        }

        public List<Models.DesperfectosRepuesto> GetAll()
        {
            var lista = new List<Models.DesperfectosRepuesto>();
            using (var context = new TallerMecanicoContext())
            {
                lista = context.DesperfectosRepuestos.ToList();
            }

            return lista;
        }

    }
}
