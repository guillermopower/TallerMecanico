using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.Repuesto
{
    public interface IRepuestoDAL
    {
        public long Add(Models.Repuesto repuesto);
        public long Update(Models.Repuesto repuesto);
        public Models.Repuesto Get(long id);
        public List<Models.Repuesto> GetAll();
    }
}
