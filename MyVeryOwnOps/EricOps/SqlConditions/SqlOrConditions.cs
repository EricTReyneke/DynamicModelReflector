using DataModelReflector.Interfaces;
using EricOps.Interfaces;

namespace EricOps.SqlConditions
{
    public class SqlOrConditions : IOrConditions
    {
        public IConditions[] Conditions { get; set; }
    }
}
