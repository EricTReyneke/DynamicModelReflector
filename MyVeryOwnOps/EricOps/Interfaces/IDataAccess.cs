using System.Data;

namespace EricOps.Interfaces
{
    public interface IDataAccess
    {
        /// <summary>
        /// Retrieves Data from the Database with the Query Provided.
        /// </summary>
        /// <param name="selectStatmentString">Select Query.</param>
        /// <returns>DataTable which will be filled with the data recieves form the Query.</returns>
        DataTable RetrieveTableData(string selectStatmentString);

        /// <summary>
        /// Deletes data from the Database using the Delete Query provided.
        /// </summary>
        /// <param name="deleteStatement">Delete query.</param>
        void DeleteTableData(string deleteStatement);

        /// <summary>
        /// Inserts data into the Database using the Insert Query provided.
        /// </summary>
        /// <param name="insertStatement">Insert Query.</param>
        void InsertTableData(string insertStatement);

        /// <summary>
        /// Updates data in the Database using the Update Query provided.
        /// </summary>
        /// <param name="updateStatement">Update Query.</param>
        void UpdateTableData(string updateStatement);
    }
}