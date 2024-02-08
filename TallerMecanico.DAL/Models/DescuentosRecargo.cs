using System;
using System.Collections.Generic;

namespace TallerMecanico.DAL.Models;

public partial class DescuentosRecargo
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal? ValorAbsoluto { get; set; }

    public decimal? ValorPorcentual { get; set; }

    public bool EsValorAbsoluto { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }
}
