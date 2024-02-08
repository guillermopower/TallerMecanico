namespace TallerMecanico.Entities.Models
{
    public class Automovil:Vehiculo
    {
        public enum TipoAutomovil { Compacto, Sedan, Monovolumen, Utilitario , Lujo }

		private long _id;
		public long Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private long _idVehiculo;
		public long IdVehiculo
		{
			get { return _idVehiculo; }
			set { _idVehiculo = value; }
		}

		private int _tipo;
		public int Tipo
		{
			get { return _tipo; }
			set { _tipo = value; }
		}

		private int _cantidadDePuertas;
		public int CantidadDePuertas
        {
			get { return _cantidadDePuertas; }
			set { _cantidadDePuertas = value; }
		}

        public static List<string> GetAutomovilTypes()
        {
            return Enum.GetNames(typeof(TipoAutomovil)).ToList();
        }
    }
}
