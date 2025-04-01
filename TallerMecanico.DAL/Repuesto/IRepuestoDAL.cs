namespace TallerMecanico.DAL.Repuesto
{
    public interface IRepuestoDAL
    {
        public Task<long> Add(Models.Repuesto repuesto);
        public Task<long> Update(Models.Repuesto repuesto);
        public Task<Models.Repuesto> Get(long id);
        public Task<List<Models.Repuesto>> GetAll();
    }
}
