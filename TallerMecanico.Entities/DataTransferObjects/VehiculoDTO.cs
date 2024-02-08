//﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TallerMecanico.Entities.DataTransferObjects
{
    public class VehiculoDTO
    {
        [DataType(DataType.Text)]
        public string Marca { get; set; } = null!;

        [DataType(DataType.Text)]
        public string Modelo { get; set; } = null!;

        public string Patente { get; set; } = null!;
        public long IdVehiculo { get; set; }

        public short? Tipo { get; set; }

        public DateTime? CantidadPuertas { get; set; }
        public bool EsMoto { get; set; }
        public string? Cilindrada { get; set; }
    }
}
