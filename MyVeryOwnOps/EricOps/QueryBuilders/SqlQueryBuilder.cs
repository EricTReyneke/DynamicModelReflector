using DataModelReflector.Interfaces;
using EricOps.Interfaces;
using EricOps.SqlConditions;
using System;
using System.Linq;
using System.Text;

namespace EricOps.QueryBuilders
{
    public class SqlQueryBuilder : IQueryBuilder
    {
        #region Public Methods
        public string BuildQueryStatement<TModel>(IConditions conditions = null)
        {
            string tableName = typeof(TModel).Name;
            if (conditions == null)
                return $"Select * From {tableName}";

            var sqlStatement = new StringBuilder($"Select * From {tableName} Where ");

            foreach (var condition in conditions.GetType().GetProperties())
            {
                var conditionValues = (object[])condition.GetValue(conditions);
                if (conditionValues != null)
                {
                    try
                    {
                        for (int i = 0; i < conditionValues.Length; i++)
                        {
                            if (conditionValues.GetType() == typeof(SqlOrConditions[]))
                            {
                                if (sqlStatement.ToString().EndsWith(" And "))
                                    sqlStatement.Length -= " And".Length;

                                AddOrCondition<TModel>(sqlStatement, conditionValues, i);
                            }
                            else
                                AddCondition<TModel>(sqlStatement, conditionValues[i]);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"An error occurred: {e.Message}");
                        throw;
                    }
                }
            }

            // remove trailing " And " or " Or "
            return sqlStatement.ToString().TrimEnd(new[] { ' ', 'd', 'n', 'A', 'r', 'O' });
        }
        #endregion

        #region Private Methods
        private void AddOrCondition<TModel>(StringBuilder sqlStatement, object[] conditionValues, int i)
        {
            string condition = BuildQueryStatement<TModel>(((IOrConditions)conditionValues[i]).Conditions[i])
                .Split(new[] { "Where" }, StringSplitOptions.RemoveEmptyEntries)
                .Last()
                .Replace("And", "Or");

            sqlStatement.Append($" Or ({condition}) Or ");
        }

        private void AddCondition<TModel>(StringBuilder sqlStatement, object conditionValue) =>
            sqlStatement.Append($"{AddConditionToQuery<TModel>((IQueryCreator)conditionValue)} And ");

        private string AddConditionToQuery<TModel>(IQueryCreator conditionValues) =>
            conditionValues.GenerateConditionString<TModel>();
        #endregion
    }
}