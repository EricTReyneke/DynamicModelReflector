using DataModelReflector.Interfaces;
using System.Text;

namespace EricOps.Interfaces
{
    public interface IQueryBuilder
    {
        /// <summary>
        /// Builds Load Query.
        /// </summary>
        /// <typeparam name="TModel">POCO model which will match the table in the Database.</typeparam>
        /// <param name="conditions">Condtions to add onto the Load query.</param>
        /// <returns>Load Query Statment.</returns>
        string LoadQueryBuilder<TModel>(IConditions conditions = null) where TModel : class, new();

        /// <summary>
        /// Builds Delete Query.
        /// </summary>
        /// <typeparam name="TModel">POCO model which will match the table in the Database.</typeparam>
        /// <param name="conditions">Condtions to add onto the Delete query.</param>
        /// <returns>Delete Query Statment.</returns>
        string DeleteQueryBuilder<TModel>(IConditions conditions = null) where TModel : class, new();

        /// <summary>
        /// Builds Insert Query.
        /// </summary>
        /// <typeparam name="TModel">POCO model which will match the table in the Database.</typeparam>
        /// <param name="conditions">Condtions to add onto the Insert query.</param>
        /// <returns>Insert Query Statment.</returns>
        string InsertQueryBuilder<TModel>(IConditions conditions) where TModel : class, new();

        /// <summary>
        /// Builds Update Query
        /// </summary>
        /// <typeparam name="TModel">POCO model which will match the table in the Database.</typeparam>
        /// <param name="conditions">Condtions to add onto the Update query.</param>
        /// <returns>Update Query Statment.</returns>
        string UpdateQueryBuilder<TModel>(IConditions conditions) where TModel : class, new();

        /// <summary>
        /// Buildes conditions into the StringBuilder provided.
        /// </summary>
        /// <typeparam name="TModel">POCO model which will match the table in the Database.</typeparam>
        /// <param name="queryStatement">Stringbuilder Which will be used to add the Conditions to.</param>
        /// <param name="conditions">Condtions to add onto a query.</param>
        void ConditionBuilder<TModel>(StringBuilder queryStatement, IConditions conditions = null) where TModel : class, new();
    }
}