using DataModelReflector.Interfaces;

namespace EricOps.Interfaces
{
    public interface IQueryBuilder
    {
        string BuildQueryStatement<TModel>(IConditions conditions = null);
    }
}