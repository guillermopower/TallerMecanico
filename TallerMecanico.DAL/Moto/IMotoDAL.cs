using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.Moto
{
    public interface IMotoDAL
    {
        public List<TallerMecanico.DAL.Models.Moto> GetAll();
        public TallerMecanico.DAL.Models.Moto Get(long id);
        public long SaveOrUpdate(TallerMecanico.DAL.Models.Moto item);
    }
}
