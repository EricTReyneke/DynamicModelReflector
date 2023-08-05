using EricOps.ComponentInterfaces;
using EricOps.Interfaces;

namespace EricOps.SqlConditions
{
    public class SqlInsertConditions : IInsertConditions
    {
        public IInsert[] Inserts { get; set; }
    }
}