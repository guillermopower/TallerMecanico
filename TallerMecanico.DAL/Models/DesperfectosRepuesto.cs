using System;
using System.Collections.Generic;

namespace TallerMecanico.DAL.Models;

public partial class DesperfectosRepuesto
{
    public long Id { get; set; }

    public long IdDesperfecto { get; set; }

    public long IdRepuesto { get; set; }

    public virtual Desperfecto IdDesperfectoNavigation { get; set; } = null!;

    public virtual Repuesto IdRepuestoNavigation { get; set; } = null!;
}
