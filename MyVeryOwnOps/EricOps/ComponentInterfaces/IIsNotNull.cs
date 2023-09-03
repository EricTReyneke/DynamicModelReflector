using EricOps.Interfaces;

namespace EricOps.ComponentInterfaces
{
    public interface IIsNotNull : IQueryCreator
    {
        string ColumnName { get; set; }
    }
}