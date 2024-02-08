namespace TallerMecanico.Business.Desperfectos
{
    public interface IDesperfectoBusiness
    {
        public bool CargarDefectos(long idPresupuesto, List<TallerMecanico.Entities.Models.Desperfecto> desperfectos);
        
    }
}
