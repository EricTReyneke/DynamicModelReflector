using DataModelReflector.Interfaces;
using EricOps.BaseClass;
using System;

namespace DataModelReflector.SqlConditions
{
    public class SqlNotEquals : ValidateQueryValues, INotEquals
    {
        public string ColumnName { get; set; }
        public string Value { get; set; }

        public SqlNotEquals(string columnName, string value)
        {
            ColumnName = columnName;
            Value = value;
        }

        #region Public Methods
        public string GenerateConditionString<TModel>() =>
            $"{ColumnName} <> {ValidateTypeForQuotations(ColumnName, Value, typeof(TModel))}";
        #endregion
    }
}
