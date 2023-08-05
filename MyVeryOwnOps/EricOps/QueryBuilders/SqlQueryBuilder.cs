using DataModelReflector.Interfaces;
using EricOps.Exceptions;
using EricOps.Interfaces;
using System;
using System.Reflection;
using System.Text;

namespace EricOps.QueryBuilders
{
    public class SqlQueryBuilder : IQueryBuilder
    {
        #region Fields
        private string _tableName;
        #endregion

        #region Public Methods
        public string LoadQueryBuilder<TModel>(IConditions conditions = null) where TModel : class, new()
        {
            _tableName = typeof(TModel).Name;

            conditions.InsertConditions = null;
            conditions.UpdateConditions = null;

            StringBuilder queryBuilder = new StringBuilder($"Select * From {_tableName}");

            if (conditions != null)
            {
                queryBuilder.Append(" Where ");
                ConditionBuilder<TModel>(queryBuilder, conditions);
            }

            return queryBuilder.ToString();
        }

        public string DeleteQueryBuilder<TModel>(IConditions conditions = null) where TModel : class, new()
        {
            _tableName = typeof(TModel).Name;

            conditions.InsertConditions = null;
            conditions.UpdateConditions = null;

            StringBuilder queryBuilder = new StringBuilder($"Delete From {_tableName}");

            if (conditions != null)
            {
                queryBuilder.Append(" Where ");
                ConditionBuilder<TModel>(queryBuilder, conditions);
            }

            return queryBuilder.ToString();
        }

        public string InsertQueryBuilder<TModel>(IConditions conditions) where TModel : class, new()
        {
            if (conditions.InsertConditions == null)
                throw new UserExceptions("Insert Reflector Function requirs InsertConditions.");

            conditions.AndConditions = null;
            conditions.OrConditions = null;
            conditions.UpdateConditions = null;

            _tableName = typeof(TModel).Name;

            StringBuilder queryBuilder = new StringBuilder($"Insert Into {_tableName}");

            ConditionBuilder<TModel>(queryBuilder, conditions);

            return queryBuilder.ToString();
        }

        public string UpdateQueryBuilder<TModel>(IConditions conditions) where TModel : class, new()
        {
            if (conditions.UpdateConditions == null)
                throw new UserExceptions("Update Reflector Function requirs UpdateConditions.");

            conditions.InsertConditions = null;

            _tableName = typeof(TModel).Name;

            StringBuilder queryBuilder = new StringBuilder($"Update {_tableName}");

            if (conditions != null)
            {
                queryBuilder.Append(" Set ");
                ConditionBuilder<TModel>(queryBuilder, conditions);
            }

            return queryBuilder.ToString();
        }

        public void ConditionBuilder<TModel>(StringBuilder queryStatement, IConditions conditions = null) where TModel : class, new()
        {
            foreach (PropertyInfo outerConditions in conditions.GetType().GetProperties())
            {
                object innerConditions = outerConditions.GetValue(conditions);

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
                                ValidateCondition<TModel>(queryStatement, conditionValues[i], outerConditions.PropertyType.Name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"An error occurred: {e.Message}");
                            throw;
                        }
                    }
                }
            }

            queryStatement.ToString().TrimEnd(new[] { ' ', 'd', 'n', 'A', 'r', 'O', ',' });
        }
        #endregion

        #region Private Methods
        private void AddConditionToQuery<TModel>(StringBuilder queryStatement, IQueryCreator conditionValue) =>
            queryStatement.Append(conditionValue.GenerateConditionString<TModel>());

        private void ValidateCondition<TModel>(StringBuilder queryStatement, IQueryCreator conditionValues, string ConditionTypeName)
        {
            switch (ConditionTypeName)
            {
                case "IUpdateConditions":
                    AddConditionToQuery<TModel>(queryStatement, conditionValues);
                    queryStatement.Append(", ");
                    break;
                case "IAndConditions":
                    AddConditionToQuery<TModel>(queryStatement, conditionValues);
                    queryStatement.Append(" And ");
                    break;
                case "IOrConditions":
                    AddConditionToQuery<TModel>(queryStatement, conditionValues);
                    queryStatement.Append(" Or ");
                    break;
                case "IInsertConditions":
                    
                    break;
            }
        }
        #endregion
    }
}