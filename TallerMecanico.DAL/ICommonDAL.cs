using Microsoft.Data.SqlClient;
using System.Data;

namespace TallerMecanico.DAL
{
    public interface ICommonDAL
    {
        public DataSet ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters);
    }
}