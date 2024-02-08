using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Common;

namespace TallerMecanico.DAL
{
    public class CommonDAL : ICommonDAL
    {
        private string _connectionString;

        private readonly IConfigurationService configurationService;
        public CommonDAL(IConfigurationService conf)
        {
            this.configurationService = conf;
            _connectionString = configurationService.GetConfig().ConnectionString;

        }
        public DataSet ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            DataSet salida = new DataSet();

            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand sqlCmd = new SqlCommand
                    {
                        CommandText = procedureName,
                        CommandTimeout = 7200,
                        CommandType = CommandType.StoredProcedure,
                        Connection = conn
                    };

                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    foreach (SqlParameter pmParameter in parameters)
                    {
                        sqlCmd.Parameters.Add(pmParameter);
                    }

                    SqlDataAdapter daSP = new SqlDataAdapter(sqlCmd);
                    daSP.Fill(salida);
                }
                catch (Exception ex)
                {
                    
                }
            }
            return salida;

        }
    }
}