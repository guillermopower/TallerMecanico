using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.Automovil
{
    public class AutomovilDAL : IAutomovilDAL
    {
        public AutomovilDAL() { }

        public List<Automovile> GetAll()
        {
            var lista = new List<Automovile>();
            using (var context = new TallerMecanicoContext())
            {
                lista = context.Automoviles.ToList();
            }

            return lista;
        }

        public Automovile Get(long id)
        {
            var item = new Automovile();
            using (var context = new TallerMecanicoContext())
            {
                item = context.Automoviles.FirstOrDefault(x => x.Id.Equals(id));
            }

            return item;
        }
        public long SaveOrUpdate(Automovile item)
        {
            long id = 0;
            using (var context = new TallerMecanicoContext())
            {
                if (item.Id.Equals(0)) context.Automoviles.Add(item); else context.Automoviles.Update(item);
                context.SaveChanges();
                id = item.Id;
            }
            return id;
        }
    }
}
