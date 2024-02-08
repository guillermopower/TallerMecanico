using System;
using System.Collections.Generic;

namespace TallerMecanico.DAL.Models;

public partial class Automovile
{
    public long Id { get; set; }

    public long IdVehiculo { get; set; }

    public short? Tipo { get; set; }

    public DateTime? CantidadPuertas { get; set; }

    public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
}
