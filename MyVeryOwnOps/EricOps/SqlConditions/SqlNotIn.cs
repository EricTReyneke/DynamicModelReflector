using DataModelReflector.Interfaces;
using EricOps.BaseClass;
using System;

namespace DataModelReflector.Conditions
{
    public class SqlNotIn : ValidateQueryValues, INotIn
    {
        public string ColumnName { get; set; }
        public string[] Values { get; set; }

        public SqlNotIn(string columnName, string[] values)
        {
            ColumnName = columnName;
            Values = values;
        }

        #region Public Methods
        public string GenerateConditionString<TModel>() =>
            $"{ColumnName} Not In ({RetrieveValuesInArray<TModel>(ColumnName, Values)})";
        #endregion
    }
}
