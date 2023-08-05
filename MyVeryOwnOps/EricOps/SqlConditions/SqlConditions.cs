using DataModelReflector.Interfaces;
using EricOps.Interfaces;

namespace DataModelReflector.Conditions
{
    public struct SqlConditions : IConditions
    {
        public IAndConditions AndConditions { get; set; }
        public IOrConditions OrConditions { get; set; }
        public IInsertConditions InsertConditions { get; set; }
        public IUpdateConditions UpdateConditions { get; set; }
    }
}