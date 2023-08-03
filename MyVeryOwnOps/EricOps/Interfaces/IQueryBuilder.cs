using DataModelReflector.Interfaces;

namespace EricOps.Interfaces
{
    public interface IQueryBuilder
    {
        string BuildSqlStatment<TModel>(IConditions conditions);
    }
}