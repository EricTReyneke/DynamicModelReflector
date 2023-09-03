using EricOps.BaseClass;
using EricOps.ComponentInterfaces;

namespace EricOps.SqlConditions
{
    public class SqlIsNull : ValidateQueryValues, IIsNull
    {
        public string ColumnName { get; set; }

        public SqlIsNull(string columnName)
        {
            ColumnName = columnName;
        }

        public string GenerateConditionString<TModel>() =>
            $"{ColumnName} Is Null";
    }
}