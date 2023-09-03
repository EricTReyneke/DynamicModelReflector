using EricOps.SqlConditions;

namespace EricOps.Interfaces
{
    public interface IInsertConditions : IConditions
    {
        IInsertContext InsertContext { get; set; }
    }
}