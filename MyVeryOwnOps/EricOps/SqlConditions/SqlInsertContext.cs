using EricOps.ComponentInterfaces;
using EricOps.Interfaces;

namespace EricOps.BaseClass
{
    public class SqlInsertContext : IInsertContext
    {
        public IInsert[] Inserts { get; set; }
    }
}