namespace TallerMecanico.Entities.DataTransferObjects
{
    public class DiagnosticarDTO
    {
        public long IdPresupuesto { get; set; }
        public List<TallerMecanico.Entities.Models.Desperfecto> Desperfectos { get; set; }
    }
}
