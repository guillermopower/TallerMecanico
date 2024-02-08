
namespace TallerMecanico.DAL.Presupuesto
{
    public interface IPresupuestoDAL
    {
        public Task<long> AddOrUpdate(Models.Presupuesto presupuesto);
       
        public Task<DAL.Models.Presupuesto> Get(long idPresupuesto);
    }
}
