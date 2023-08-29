using EricOps.Interfaces;

namespace DataModelReflector.Interfaces
{
    public interface IAndOrConditions : IConditions
    {
        IOrConditions OrConditions { get; set; }
        IAndConditions AndConditions { get; set; }
    }
}