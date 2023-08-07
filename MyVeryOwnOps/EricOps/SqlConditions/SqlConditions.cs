using DataModelReflector.Interfaces;
using EricOps.Interfaces;

namespace DataModelReflector.Conditions
{
    public struct SqlConditions : IConditions
    {
        public IInsertConditions InsertConditions { get; set; }
        public IUpdateConditions UpdateConditions { get; set; }
        public IAndConditions AndConditions { get; set; }
        public IOrConditions OrConditions { get; set; }
    }
}