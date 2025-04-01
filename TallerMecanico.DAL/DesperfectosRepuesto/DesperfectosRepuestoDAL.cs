using Microsoft.EntityFrameworkCore;
using TallerMecanico.DAL.DesperfectosRepuesto;
using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.DesperfectosRepuestosRepuesto
{
    public class DesperfectosRepuestoDAL : IDesperfectosRepuestoDAL
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

        public async Task<List<Models.DesperfectosRepuesto>> GetMany(long idDesperfecto)
        {
            var lista = new List<Models.DesperfectosRepuesto>();
            using (var context = new TallerMecanicoContext())
            {
                lista = await context.DesperfectosRepuestos.Where(x => x.IdDesperfecto.Equals(idDesperfecto)).ToListAsync();
            }

            return lista;
        }

        public async Task<List<Models.DesperfectosRepuesto>> GetAll()
        {
            var lista = new List<Models.DesperfectosRepuesto>();
            using (var context = new TallerMecanicoContext())
            {
                lista = await context.DesperfectosRepuestos.ToListAsync();
            }

            return lista;
        }

    }
}
