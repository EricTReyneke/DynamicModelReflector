using EricOps.Interfaces;

namespace DataModelReflector.Interfaces
{
    public interface INotEquals : IQueryCreator
    {
        string ColumnName { get; set; }
        string Value { get; set; }
    }
}
