using EricOps.Interfaces;

namespace EricOps.ComponentInterfaces
{
    public interface IUpdate : IQueryCreator
    {
        string ColumnName { get; set; }
        string NewValue { get; set; }
    }
}