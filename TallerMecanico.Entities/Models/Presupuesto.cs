namespace TallerMecanico.Entities.Models
{
    public class Presupuesto
    {
		private long _id;
		public long Id	
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _nombre;
		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}

		private string _apellido;

		public string Apellido
		{
			get { return _apellido; }
			set { _apellido = value; }
		}

		private string _email;

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		private Vehiculo _vehiculo;

		public Vehiculo Vehiculo
		{
			get { return _vehiculo; }
			set { _vehiculo = value; }
		}

	}
}
