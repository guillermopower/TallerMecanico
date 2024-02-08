using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.Desperfecto
{
    public interface IDesperfectoDAL
    {
        public long Add(Models.Desperfecto desperfecto);
        public long Update(Models.Desperfecto desperfecto);
        public Models.Desperfecto GetById(long id);
        public List<Models.Desperfecto> GetByPresupuestoId(long idPresupuesto);
        public List<Models.Desperfecto> GetAll();
    }
}
