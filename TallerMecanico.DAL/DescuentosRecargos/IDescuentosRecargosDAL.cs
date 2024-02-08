using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.DescuentosRecargos
{
    public interface IDescuentosRecargosDAL
    {
        public List<DescuentosRecargo> GetAll(bool soloActivos = false);
        public DescuentosRecargo Get(long id);
        public long SaveOrUpdate(DescuentosRecargo item);
    }
}
