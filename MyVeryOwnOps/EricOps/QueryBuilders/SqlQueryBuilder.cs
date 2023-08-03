using DataModelReflector.Interfaces;
using EricOps.Interfaces;
using System.Reflection;
using System.Text;

namespace EricOps.QueryBuilders
{
    public class SqlQueryBuilder : IQueryBuilder
    {
        #region Public Methods
        public string BuildSqlStatment<TModel>(IConditions conditions)
        {
            string tableName = typeof(TModel).Name;
            if (conditions == null)
                return $"Select * From {tableName}";

            StringBuilder sqlStatement = new StringBuilder();
            sqlStatement.Append($"Select * From {tableName} Where ");

            foreach (PropertyInfo condition in conditions.GetType().GetProperties())
            {
                if (condition.GetValue(conditions) != null)
                {
                    try
                    {
                        object[] conditionValues = (object[])condition.GetValue(conditions);
                        for (int i = 0; i < conditionValues.Length; i++)
                        {
                            string separator = conditionValues.GetType() == typeof(IOrConditions) ? " Or " : " And ";

                            sqlStatement.Append(AddConditionToQuery<TModel>(conditionValues[i]));

                            if (i != conditionValues.Length - 1)
                                sqlStatement.Append(separator);
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }

            return sqlStatement.ToString().Trim();
        }
        #endregion

        #region Private Methods
        private string AddConditionToQuery<TModel>(object conditionValues) =>
            //conditionValues.GenerateConditionString<TModel>();
            conditionValues.GetType().GetMethod("GenerateConditionString")
                .Invoke(conditionValues, new object[] { typeof(TModel) }).ToString();
        #endregion
    }
}