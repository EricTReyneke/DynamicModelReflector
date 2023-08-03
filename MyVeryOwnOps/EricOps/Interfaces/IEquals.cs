using EricOps.Interfaces;

namespace DataModelReflector.Interfaces
{
    public interface IEquals : IQueryCreator
    {
        string ColumnName { get; set; }
        string Value { get; set; }
    }
}
