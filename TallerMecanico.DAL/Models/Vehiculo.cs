using System;
using System.Collections.Generic;

namespace TallerMecanico.DAL.Models;

public partial class Vehiculo
{
    public long Id { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Patente { get; set; } = null!;

    public DateTime? FechaIngreso { get; set; }

    public virtual ICollection<Automovile> Automoviles { get; } = new List<Automovile>();

    public virtual ICollection<Moto> Motos { get; } = new List<Moto>();

    public virtual ICollection<Presupuesto> Presupuestos { get; } = new List<Presupuesto>();
}
