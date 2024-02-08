using System;
using System.Collections.Generic;

namespace TallerMecanico.DAL.Models;

public partial class Repuesto
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? Precio { get; set; }

    public virtual ICollection<DesperfectosRepuesto> DesperfectosRepuestos { get; } = new List<DesperfectosRepuesto>();
}
