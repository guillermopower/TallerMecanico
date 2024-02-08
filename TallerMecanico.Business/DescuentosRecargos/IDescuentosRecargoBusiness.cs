using TallerMecanico.DAL.Models;

namespace TallerMecanico.Business.DescuentosRecargos
{
    public interface IDescuentosRecargoBusiness
    {
        public Task<List<DescuentosRecargo>> GetAll(bool soloActivos = false);
        public Task<DescuentosRecargo> Get(long id);
        public Task<long> SaveOrUpdate(DescuentosRecargo item);
    }
}
