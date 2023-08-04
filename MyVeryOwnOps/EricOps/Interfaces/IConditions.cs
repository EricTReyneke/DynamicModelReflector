using DataModelReflector.SqlConditions;
using EricOps.Interfaces;

namespace DataModelReflector.Interfaces
{
    public interface IConditions
    {
        IOrConditions OrConditions { get; set; }

        IAndConditions AndConditions { get; set; }
    }
}
