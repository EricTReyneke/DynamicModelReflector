using EricOps.Interfaces;
using Microsoft.SqlServer.Server;

namespace EricOps.ComponentInterfaces
{
    public interface IIsNull : IQueryCreator
    {
        string ColumnName { get; set; }
    }
}