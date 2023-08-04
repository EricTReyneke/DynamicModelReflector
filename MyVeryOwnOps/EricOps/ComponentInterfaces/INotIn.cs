using EricOps.Interfaces;

namespace DataModelReflector.Interfaces
{
    public interface INotIn : IQueryCreator
    {
        string ColumnName { get; set; }
        string[] Values { get; set; }
    }
}
