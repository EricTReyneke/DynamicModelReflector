using EricOps.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EricOps.DataRecievers
{
    public class SqlDataReciever : IDataReciever
    {
        #region Fields
        private string _connectionString;
        #endregion

        #region Constructors
        public SqlDataReciever()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        }
        #endregion

        #region Public Methods
        public DataTable RetrieveTableData(string selectStatmentString)
        {
            using (SqlConnection sqlConnection = CreateConnection())
            {
                try
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectStatmentString, sqlConnection))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        #endregion

        #region Private Methods
        private SqlConnection CreateConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
        #endregion
    }
}
