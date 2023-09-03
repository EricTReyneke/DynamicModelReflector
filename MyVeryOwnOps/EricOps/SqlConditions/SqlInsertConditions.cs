using EricOps.ComponentInterfaces;
using EricOps.Interfaces;

namespace EricOps.SqlConditions
{
    public class SqlInsertConditions : IInsertConditions
    {
        public IInsertContext InsertContext { get; set; }
    }
}