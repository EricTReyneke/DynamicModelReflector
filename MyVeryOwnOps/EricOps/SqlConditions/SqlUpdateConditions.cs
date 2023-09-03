using EricOps.Interfaces;

namespace EricOps.SqlConditions
{
    public class SqlUpdateConditions : IUpdateConditions
    {
        public IUpdateContext UpdateContext { get; set; }
        public IAndConditions AndConditions { get; set; }
        public IOrConditions OrConditions { get; set; }
    }
}