namespace TallerMecanico.Business.Presupuesto
{
    public interface IPresupuestoBusiness
    {
        public Task<decimal?> CalcularTotal(long idPresupuesto);
        public Task<long> AddOrUpdate(Entities.Models.Presupuesto presupuesto);
        public Task<DAL.Models.Presupuesto> Get(long idPresupuesto);
    }
}
