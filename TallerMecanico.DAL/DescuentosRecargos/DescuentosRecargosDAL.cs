using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.DescuentosRecargos
{
    public class DescuentosRecargosDAL: IDescuentosRecargosDAL
    {
        public List<DescuentosRecargo> GetAll(bool soloActivos = false)
        {
            var lista = new List<DescuentosRecargo>();
            using (var context = new TallerMecanicoContext())
            {
                if(soloActivos)
                    lista = context.DescuentosRecargos.Where(x=>x.Activo.Equals(true)).ToList();
                else
                    lista = context.DescuentosRecargos.ToList();
            }

            return lista;
        }

        public DescuentosRecargo Get(long id)
        {
            var item = new DescuentosRecargo();
            using (var context = new TallerMecanicoContext())
            {
                item = context.DescuentosRecargos.FirstOrDefault(x => x.Id.Equals(id));
            }

            return item;
        }
        public long SaveOrUpdate(DescuentosRecargo item)
        {
            long id = 0;
            using (var context = new TallerMecanicoContext())
            {
                if (item.Id.Equals(0)) context.DescuentosRecargos.Add(item); else context.DescuentosRecargos.Update(item);
                context.SaveChanges();
                id = item.Id;
            }
            return id;
        }
    }
}
