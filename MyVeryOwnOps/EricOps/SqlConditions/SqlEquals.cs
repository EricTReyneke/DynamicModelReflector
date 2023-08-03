using DataModelReflector.Interfaces;
using EricOps.BaseClass;
using System;

namespace DataModelReflector.SqlConditions
{
    public class SqlEquals : ValidateQueryValues, IEquals
    {
        public string ColumnName { get; set; }
        public string Value { get; set; }

        public SqlEquals(string columnName, string value)
        {
            ColumnName = columnName;
            Value = value;
        }

        #region Public Methods
        public string GenerateConditionString(Type dataModelType) =>
            $"{ColumnName} = {ValidateTypeForQuotations(ColumnName, Value, dataModelType)}";
        #endregion
    }
}