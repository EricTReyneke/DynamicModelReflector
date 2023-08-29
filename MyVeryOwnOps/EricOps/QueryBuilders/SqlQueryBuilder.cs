using DataModelReflector.Interfaces;
using EricOps.Exceptions;
using EricOps.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EricOps.QueryBuilders
{
    public class SqlQueryBuilder : IQueryBuilder
    {
        #region Fields
        private Dictionary<string, List<string>> _insertDict;
        #endregion

        #region Public Methods
        public string LoadQueryBuilder<TModel>(IConditions conditions = null) where TModel : class, new()
        {
            if(conditions != null)
            {
                conditions.InsertConditions = null;
                conditions.UpdateConditions = null;
            }

            StringBuilder queryBuilder = new StringBuilder($"Select * From {typeof(TModel).Name}");

            if (conditions != null)
            {
                queryBuilder.Append(" Where ");
                ConditionBuilder<TModel>(queryBuilder, conditions);
            }

            return queryBuilder.ToString();
        }

        public string DeleteQueryBuilder<TModel>(IConditions conditions = null) where TModel : class, new()
        {
            if (conditions != null)
            {
                conditions.InsertConditions = null;
                conditions.UpdateConditions = null;
            }

            StringBuilder queryBuilder = new StringBuilder($"Delete {typeof(TModel).Name}");

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

            if (conditions != null)
            {
                conditions.AndConditions = null;
                conditions.OrConditions = null;
                conditions.UpdateConditions = null;
            }

            StringBuilder queryBuilder = new StringBuilder($"Insert Into {typeof(TModel).Name} ");

            ConditionBuilder<TModel>(queryBuilder, conditions);

            return queryBuilder.ToString();
        }

        public string UpdateQueryBuilder<TModel>(IConditions conditions) where TModel : class, new()
        {
            if (conditions.UpdateConditions == null)
                throw new UserExceptions("Update Reflector Function requirs UpdateConditions.");

            if (conditions != null)
                conditions.InsertConditions = null;

            StringBuilder queryBuilder = new StringBuilder($"Update {typeof(TModel).Name}");

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

                if (innerConditions != null && outerConditions.PropertyType.Name == "IInsertConditions")
                    BuildInsertStatement(queryStatement);
            }

            string finalQueryStatement = queryStatement.ToString().Trim();

            if (finalQueryStatement.EndsWith(" And"))
                finalQueryStatement = finalQueryStatement.Substring(0, finalQueryStatement.Length - " And".Length);
            else if (finalQueryStatement.EndsWith(" Or"))
                finalQueryStatement = finalQueryStatement.Substring(0, finalQueryStatement.Length - " Or".Length);

            queryStatement.Clear().Append(finalQueryStatement);
        }
        #endregion

        #region Private Methods
        private void AddConditionToQuery<TModel>(StringBuilder queryStatement, IQueryCreator conditionValue) =>
            queryStatement.Append(conditionValue.GenerateConditionString<TModel>());

        private void CaptureInsertValues<TModel>(IQueryCreator conditionValue)
        {
            List<string> insertValue = conditionValue.GenerateConditionString<TModel>().Split('\n').ToList();

            if (_insertDict == null)
            {
                _insertDict = new Dictionary<string, List<string>>();
                _insertDict.Add("ColumnNames", new List<string> { insertValue[0] });
                _insertDict.Add("ColumnValues", new List<string> { insertValue[1] });

                return;
            }

            _insertDict["ColumnNames"].Add(insertValue[0]);
            _insertDict["ColumnValues"].Add(insertValue[1]);
        }

        private void BuildInsertStatement(StringBuilder queryStatement) => 
            queryStatement.Append($"({string.Join(", ", _insertDict["ColumnNames"])}) " +
                $"Values ({string.Join(", ", _insertDict["ColumnValues"])})");

        private void ValidateCondition<TModel>(StringBuilder queryStatement, IQueryCreator conditionValues, string ConditionTypeName)
        {
            switch (ConditionTypeName)
            {
                case "IUpdateConditions":
                    queryStatement.Replace(" Where ", ", ");
                    AddConditionToQuery<TModel>(queryStatement, conditionValues);
                    queryStatement.Append(" Where ");
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
                    CaptureInsertValues<TModel>(conditionValues);
                    break;
            }
        }
        #endregion
    }
}