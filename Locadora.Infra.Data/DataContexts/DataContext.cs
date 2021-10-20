using Locadora.Infra.Settings;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Locadora.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        public DataContext(AppSettings appSettings)
        {
            try
            {
                SqlServerConexao = new SqlConnection(appSettings.ConnectionString);
                SqlServerConexao.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlConnection SqlServerConexao { get; set; }

        public void Dispose()
        {
            try
            {
                if (SqlServerConexao.State != ConnectionState.Closed)
                    SqlServerConexao.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
