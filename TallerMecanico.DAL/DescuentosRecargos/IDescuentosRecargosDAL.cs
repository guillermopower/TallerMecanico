using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.DescuentosRecargos
{
    public interface IDescuentosRecargosDAL
    {
        public Task<List<DescuentosRecargo>> GetAll(bool soloActivos = false);
        public Task<DescuentosRecargo> Get(long id);
        public Task<long> SaveOrUpdate(DescuentosRecargo item);
    }
}
