using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.Moto
{
    public class MotoDAL:IMotoDAL
    {
        public List<TallerMecanico.DAL.Models.Moto> GetAll()
        {
            var lista = new List<TallerMecanico.DAL.Models.Moto>();
            using (var context = new TallerMecanicoContext())
            {
                lista = context.Motos.ToList();
            }

            return lista;
        }

        public TallerMecanico.DAL.Models.Moto Get(long id)
        {
            var item = new TallerMecanico.DAL.Models.Moto();
            using (var context = new TallerMecanicoContext())
            {
                item = context.Motos.FirstOrDefault(x => x.Id.Equals(id));
            }

            return item;
        }
        public long SaveOrUpdate(TallerMecanico.DAL.Models.Moto item)
        {
            long id = 0;
            using (var context = new TallerMecanicoContext())
            {
                if (item.Id.Equals(0)) context.Motos.Add(item); else context.Motos.Update(item);
                context.SaveChanges();
                id = item.Id;
            }
            return id;
        }
    }
}
