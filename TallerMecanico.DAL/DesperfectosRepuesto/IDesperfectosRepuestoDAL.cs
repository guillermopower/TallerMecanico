namespace TallerMecanico.DAL.DesperfectosRepuesto
{
    public interface IDesperfectosRepuestoDAL
    {
        public long Add(Models.DesperfectosRepuesto repuesto);
        public long Update(Models.DesperfectosRepuesto repuesto);
        public List<Models.DesperfectosRepuesto> GetMany(long id);
        public List<Models.DesperfectosRepuesto> GetAll();
    }
}
