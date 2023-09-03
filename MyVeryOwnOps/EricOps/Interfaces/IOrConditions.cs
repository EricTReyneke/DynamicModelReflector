using DataModelReflector.Interfaces;
using DataModelReflector.SqlConditions;
using EricOps.ComponentInterfaces;

namespace EricOps.Interfaces
{
    public interface IOrConditions : IComponentConditions
    {
        IBetween[] Between { get; set; }

        IIn[] In { get; set; }

        ILike[] Like { get; set; }

        INotIn[] NotIn { get; set; }

        INotLike[] NotLike { get; set; }

        IEquals[] Equals { get; set; }

        INotEquals[] NotEquals { get; set; }

        IIsNull[] IsNulls { get; set; }

        IIsNotNull[] IsNotNulls { get; set; }
    }
}