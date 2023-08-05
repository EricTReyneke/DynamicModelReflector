using EricOps.BaseClass;
using EricOps.ComponentInterfaces;

namespace EricOps.SqlConditions
{
    public class SqlUpdate : ValidateQueryValues, IUpdate
    {
        public string ColumnName { get; set; }
        public string NewValue { get; set; }

        public SqlUpdate(string columnName, string newName)
        {
            ColumnName = columnName;
            NewValue = newName;
        }

        public string GenerateConditionString<TModel>() =>
            $"{ColumnName} = {ValidateTypeForQuotations<TModel>(ColumnName, NewValue)}";
    }
}
