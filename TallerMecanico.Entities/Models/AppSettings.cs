namespace TallerMecanico.Entities.Models
{
    public class AppSettings
    {
        private string _connectionString;

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
    }
}
