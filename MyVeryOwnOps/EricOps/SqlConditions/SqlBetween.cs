using DataModelReflector.Interfaces;
using EricOps.BaseClass;
using System;

namespace DataModelReflector.Conditions
{
    public class SqlBetween : ValidateQueryValues, IBetween
    {
        public string ColumnName { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }

        public SqlBetween(string columnName, string value1, string value2)
        {
            ColumnName = columnName;
            Value1 = value1;
            Value2 = value2;
        }

        #region Public Methods
        public string GenerateConditionString<TModel>() =>
            $"{ColumnName} Between {ValidateTypeForQuotations(ColumnName, Value1, typeof(TModel))} " +
                $"And {ValidateTypeForQuotations(ColumnName, Value2, typeof(TModel))}";
        #endregion
    }
}
