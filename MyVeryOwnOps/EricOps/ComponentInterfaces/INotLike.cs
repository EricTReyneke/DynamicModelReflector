using EricOps.Interfaces;

namespace DataModelReflector.SqlConditions
{
    public interface INotLike : IQueryCreator
    {
        string ColumnName { get; set; }
        string Pattern { get; set; }
    }
}
