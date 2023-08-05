using System.Collections.Generic;

namespace DataModelReflector.Interfaces
{
    public interface IDataModelReflector
    {
        /// <summary>
        /// Sets a Specified Poco data model to all the data related to that data Model in the Database.
        /// </summary>
        /// <typeparam name="TModel">Specified Poco class Type.</typeparam>
        /// <param name="conditions">Conditions to build the Where clause.</param>
        /// <returns>IEnumerable of all the data in that database relating to the name of the Type in the Database.</returns>
        IEnumerable<TModel> Load<TModel>(IConditions conditions = null) where TModel : class, new();

        /// <summary>
        /// Deletes rows out of the database using the Poco class name as the Table name 
        /// and the Conditions provided in the IConditions.
        /// </summary>
        /// <typeparam name="TModel">Specified Poco class Type.</typeparam>
        /// <param name="conditions">Conditions to build the Where clause.</param>
        void Delete<TModel>(IConditions conditions = null) where TModel : class, new();

        /// <summary>
        /// Updates data in the database using the Poco class name as the Table name 
        /// and the Conditions provided in the IConditions.
        /// </summary>
        /// <typeparam name="TModel">Specified Poco class Type.</typeparam>
        /// <param name="conditions">Conditions to build the Where and the Set Clause.</param>
        void Update<TModel>(IConditions conditions = null) where TModel : class, new();

        /// <summary>
        /// Inserts data into the Database using the Poco class name as the Table name 
        /// and the IInsertConditions in the IConditions provided.
        /// </summary>
        /// <typeparam name="TModel">Specified Poco class Type.</typeparam>
        /// <param name="conditions">Conditions to build the Where and the Values Clause.</param>
        void Insert<TModel>(IConditions conditions = null) where TModel : class, new();
    }
}
