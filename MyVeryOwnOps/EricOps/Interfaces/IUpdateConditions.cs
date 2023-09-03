using EricOps.SqlConditions;

namespace EricOps.Interfaces
{
    public interface IUpdateConditions : IConditions
    {
        IUpdateContext UpdateContext { get; set; }
        IAndConditions AndConditions { get; set; }
        IOrConditions OrConditions { get; set; }
    }
}