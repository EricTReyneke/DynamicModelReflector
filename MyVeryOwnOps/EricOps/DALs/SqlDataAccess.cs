using EricOps.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EricOps.DALs
{
    public class SqlDataAccess : IDataAccess
    {
        #region Fields
        private string _connectionString;
        #endregion

        #region Constructors
        public SqlDataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        }
        #endregion

        #region Public Methods
        public DataTable RetrieveTableData(string selectStatment)
        {
            using (SqlConnection sqlConnection = CreateConnection())
            {
                try
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectStatment, sqlConnection))
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

        public void DeleteTableData(string deleteStatement)
        {
            using (SqlConnection sqlConnection = CreateConnection())
                using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection))
                    deleteCommand.ExecuteNonQuery();
        }

        public void InsertTableData(string insertStatement)
        {
            using (SqlConnection sqlConnection = CreateConnection())
                using (SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection))
                    insertCommand.ExecuteNonQuery();
        }

        public void UpdateTableData(string updateStatement)
        {
            using (SqlConnection sqlConnection = CreateConnection())
                using (SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection))
                    updateCommand.ExecuteNonQuery();
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
