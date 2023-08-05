using EricOps.ComponentInterfaces;
using EricOps.Interfaces;

namespace EricOps.SqlConditions
{
    public class SqlUpdateConditions : IUpdateConditions
    {
        public IUpdate[] Updates { get; set; }
    }
}