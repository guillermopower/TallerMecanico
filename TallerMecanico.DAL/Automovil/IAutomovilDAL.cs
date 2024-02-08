using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.Automovil
{
    public interface IAutomovilDAL
    {
        public List<Automovile> GetAll();
        public Automovile Get(long id);
        public long SaveOrUpdate(Automovile item);
    }
}
