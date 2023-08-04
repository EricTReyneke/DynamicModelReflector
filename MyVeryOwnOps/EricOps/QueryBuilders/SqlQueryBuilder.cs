using DataModelReflector.Interfaces;
using EricOps.Interfaces;
using EricOps.SqlConditions;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EricOps.QueryBuilders
{
    public class SqlQueryBuilder : IQueryBuilder
    {
        #region Public Methods
        public string BuildQueryStatement<TModel>(IConditions conditions = null)
        {
            string tableName = typeof(TModel).Name;

            if (conditions == null) return $"Select * From {tableName}";

            StringBuilder sqlStatement = new StringBuilder($"Select * From {tableName} Where ");

            foreach (PropertyInfo outerConditions in conditions.GetType().GetProperties())
            {
                IComponentConditions innerConditions = (IComponentConditions)outerConditions.GetValue(conditions);

                if (innerConditions == null)
                    continue;

                foreach (PropertyInfo innerCondition in innerConditions.GetType().GetProperties())
                {
                    IQueryCreator[] conditionValues = (IQueryCreator[])innerCondition.GetValue(innerConditions);

                    if (conditionValues != null)
                    {
                        try
                        {
                            for (int i = 0; i < conditionValues.Length; i++)
                                if (outerConditions.PropertyType == typeof(IOrConditions))
                                    AddOrCondition<TModel>(sqlStatement, conditionValues, i);
                                else
                                    AddCondition<TModel>(sqlStatement, conditionValues[i]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"An error occurred: {e.Message}");
                            throw;
                        }
                    }
                }
            }

            // remove trailing " And " or " Or "
            return sqlStatement.ToString().TrimEnd(new[] { ' ', 'd', 'n', 'A', 'r', 'O' });
        }
        #endregion

        #region Private Methods
        private void AddOrCondition<TModel>(StringBuilder sqlStatement, IQueryCreator[] conditionValues, int i) =>
            sqlStatement.Append($"{conditionValues[i].GenerateConditionString<TModel>()} Or ");

        private void AddCondition<TModel>(StringBuilder sqlStatement, object conditionValue) =>
            sqlStatement.Append($"{AddConditionToQuery<TModel>((IQueryCreator)conditionValue)} And ");

        private string AddConditionToQuery<TModel>(IQueryCreator conditionValues) =>
            conditionValues.GenerateConditionString<TModel>();
        #endregion
    }
}