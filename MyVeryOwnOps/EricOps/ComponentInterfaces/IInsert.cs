using EricOps.Interfaces;

namespace EricOps.ComponentInterfaces
{
    public interface IInsert : IQueryCreator
    {
        string ColumnName { get; set; }
        string Value { get; set; }
    }
}