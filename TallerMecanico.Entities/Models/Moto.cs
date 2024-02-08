namespace TallerMecanico.Entities.Models
{
    public class Moto:Vehiculo
    {
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

        private string _cilindrada;

        public string Cilindrada
        {
            get { return _cilindrada; }
            set { _cilindrada = value; }
        }

    }
}
