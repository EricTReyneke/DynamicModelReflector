using DataModelReflector.Interfaces;
using EricOps.BaseClass;
using System;

namespace DataModelReflector.Conditions
{
    public class SqlIn : ValidateQueryValues, IIn
    {
        public string ColumnName { get; set; }
        public string[] Values { get; set; }

        public SqlIn(string columnName, string[] values)
        {
            ColumnName = columnName;
            Values = values;
        }

        #region Public Methods
        public string GenerateConditionString<TModel>() =>
            $"{ColumnName} In ({RetrieveValuesInArray(ColumnName, Values, typeof(TModel))})";
        #endregion
    }
}
