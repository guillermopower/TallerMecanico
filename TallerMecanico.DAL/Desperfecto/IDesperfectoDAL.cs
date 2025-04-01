namespace TallerMecanico.DAL.Desperfecto
{
    public interface IDesperfectoDAL
    {
        long Add(Models.Desperfecto desperfecto);
        long Update(Models.Desperfecto desperfecto);
        Models.Desperfecto GetById(long id);
        Task<List<Models.Desperfecto>> GetByPresupuestoId(long idPresupuesto);
        List<Models.Desperfecto> GetAll();
    }
}
