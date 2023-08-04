using DataModelReflector.SqlConditions;
using EricOps.BaseClass;
using System;

namespace DataModelReflector.Conditions
{
    public class SqlNotLike : ValidateQueryValues, INotLike
    {
        public string ColumnName { get; set; }
        public string Pattern { get; set; }

        public SqlNotLike(string columnName, string pattern)
        {
            ColumnName = columnName;
            Pattern = pattern;
        }

        #region Public Methods
        public string GenerateConditionString<TModel>() =>
            $"{ColumnName} Not Like '{Pattern}'";
        #endregion
    }
}
