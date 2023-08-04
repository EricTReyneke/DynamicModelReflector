using DataModelReflector.Interfaces;
using EricOps.BaseClass;
using System;

namespace DataModelReflector.Conditions
{
    public class SqlLike : ValidateQueryValues, ILike
    {
        public string ColumnName { get; set; }
        public string Pattern { get; set; }

        public SqlLike(string columnName, string pattern)
        {
            ColumnName = columnName;
            Pattern = pattern;
        }

        #region Public Methods
        public string GenerateConditionString<TModel>() =>
            $"{ColumnName} Like '{Pattern}'";
        #endregion
    }
}
