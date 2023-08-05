using DataModelReflector.SqlConditions;
using EricOps.Interfaces;

namespace DataModelReflector.Interfaces
{
    public interface IConditions
    {
        IUpdateConditions UpdateConditions { get; set; }

        IOrConditions OrConditions { get; set; }

        IAndConditions AndConditions { get; set; }

        IInsertConditions InsertConditions { get; set; }
    }
}