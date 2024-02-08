using System;
using System.Collections.Generic;

namespace TallerMecanico.DAL.Models;

public partial class Desperfecto
{
    public long Id { get; set; }

    public long IdPresupuesto { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal? ManoDeObra { get; set; }

    public int? Tiempo { get; set; }

    public virtual ICollection<DesperfectosRepuesto> DesperfectosRepuestos { get; } = new List<DesperfectosRepuesto>();

    public virtual Presupuesto IdPresupuestoNavigation { get; set; } = null!;
}
