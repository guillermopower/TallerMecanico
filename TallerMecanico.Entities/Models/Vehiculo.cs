namespace TallerMecanico.Entities.Models
{
    public abstract class Vehiculo
    {
		private long _id;
		public long id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _marca;
		public string Marca
		{
			get { return _marca; }
			set { _marca = value; }
		}

		private string _model;
		public string Model
		{
			get { return _model; }
			set { _model = value; }
		}

        private string _patente;
        public string Patente
        {
            get { return _patente; }
            set { _patente = value; }
        }

		private DateTime? _fechaIngreso;
		public DateTime? FechaIngreso
		{
			get { return _fechaIngreso; }
			set { _fechaIngreso = value; }
		}
	}
}
