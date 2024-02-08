using System;
using System.Collections.Generic;

namespace TallerMecanico.DAL.Models;

public partial class Presupuesto
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal Total { get; set; }

    public long IdVehiculo { get; set; }

    public virtual ICollection<Desperfecto> Desperfectos { get; } = new List<Desperfecto>();

    public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
}
