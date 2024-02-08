namespace TallerMecanico.Entities.Models
{
    public class Desperfecto
    {
        private long _id;
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Presupuesto _presupuesto;
        public Presupuesto Presupuesto
        {
            get { return _presupuesto; }
            set { _presupuesto = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private float _manoDeObra;
        public float ManoDeObra
        {
            get { return _manoDeObra; }
            set { _manoDeObra = value; }
        }

        private int _tiempo;
        public int Tiempo
        {
            get { return _tiempo; }
            set { _tiempo = value; }
        }


    }
}
