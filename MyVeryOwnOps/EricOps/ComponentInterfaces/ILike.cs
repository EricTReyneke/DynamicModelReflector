using EricOps.Interfaces;

namespace DataModelReflector.Interfaces
{
    public interface ILike : IQueryCreator
    {
        string ColumnName { get; set; }
        string Pattern { get; set; }
    }
}
