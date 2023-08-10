using EricOps.BaseClass;
using EricOps.ComponentInterfaces;

namespace EricOps.SqlConditions
{
    public class SqlInsert : ValidateQueryValues, IInsert
    {
        public string ColumnName { get; set; }
        public string Value { get; set; }

        public SqlInsert(string columnName, string value)
        {
            ColumnName = columnName;
            Value = value;
        }

        public string GenerateConditionString<TModel>() =>
            $"{ColumnName}\n{ValidateTypeForQuotations<TModel>(ColumnName, Value)}";
    }
}
