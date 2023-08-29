using EricOps.ComponentInterfaces;
using EricOps.Interfaces;

namespace EricOps.SqlConditions
{
    public class SqlUpdateContext : IUpdateContext
    {
        public IUpdate[] Updates { get; set; }
    }
}