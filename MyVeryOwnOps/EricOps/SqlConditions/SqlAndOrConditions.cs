using DataModelReflector.Interfaces;
using EricOps.Interfaces;

namespace DataModelReflector.Conditions
{
    public struct SqlAndOrConditions : IAndOrConditions
    {
        public IAndConditions AndConditions { get; set; }
        public IOrConditions OrConditions { get; set; }
    }
}