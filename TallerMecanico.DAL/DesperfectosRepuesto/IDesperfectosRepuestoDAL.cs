namespace TallerMecanico.DAL.DesperfectosRepuesto
{
    public interface IDesperfectosRepuestoDAL
    {
        public long Add(Models.DesperfectosRepuesto repuesto);
        public long Update(Models.DesperfectosRepuesto repuesto);
        public Task<List<Models.DesperfectosRepuesto>> GetMany(long id);
        public Task<List<Models.DesperfectosRepuesto>> GetAll();
    }
}
