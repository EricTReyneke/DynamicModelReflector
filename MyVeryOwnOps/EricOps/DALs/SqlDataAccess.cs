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
                catch (SqlException sqlEx)
                {
                    throw sqlEx;
                }
            }
        }

        public void DeleteTableData(string deleteStatement)
        {
            try
            {
                ExcuteQuery(deleteStatement);
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        public void InsertTableData(string insertStatement)
        {
            try
            {
                ExcuteQuery(insertStatement);
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        public void UpdateTableData(string updateStatement)
        {
            try
            {
                ExcuteQuery(updateStatement);
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Excutes sql Statment.
        /// </summary>
        /// <param name="sqlStatment">Sql statment</param>
        private void ExcuteQuery(string sqlStatment)
        {
            using (SqlConnection sqlConnection = CreateConnection())
                using (SqlCommand updateCommand = new SqlCommand(sqlStatment, sqlConnection))
                    updateCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Opens SqlConnection.
        /// </summary>
        /// <returns>Open Sql connection.</returns>
        private SqlConnection CreateConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
        #endregion
    }
}
