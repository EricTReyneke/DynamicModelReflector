using EricOps.ComponentInterfaces;

namespace EricOps.Interfaces
{
    public interface IInsertContext
    {
        IInsert[] Inserts { get; set; }
    }
}