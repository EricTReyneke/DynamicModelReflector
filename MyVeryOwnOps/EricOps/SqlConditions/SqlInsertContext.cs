using EricOps.ComponentInterfaces;
using EricOps.Interfaces;

namespace EricOps.SqlConditions
{
    public class SqlInsertContext : IInsertContext
    {
        public IInsert[] Inserts { get; set; }
    }
}
