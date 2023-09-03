using EricOps.BaseClass;
using EricOps.ComponentInterfaces;

namespace EricOps.SqlConditions
{
    public class SqlIsNotNull : ValidateQueryValues, IIsNotNull
    {
        public string ColumnName { get; set; }

        public SqlIsNotNull(string columnName)
        {
            ColumnName = columnName;
        }

        public string GenerateConditionString<TModel>() =>
            $"{ColumnName} Is Not Null";
    }
}
