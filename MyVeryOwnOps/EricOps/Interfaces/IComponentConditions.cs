using DataModelReflector.Interfaces;
using DataModelReflector.SqlConditions;

namespace EricOps.Interfaces
{
    public interface IComponentConditions
    {
        IBetween[] Between { get; set; }

        IIn[] In { get; set; }

        ILike[] Like { get; set; }

        INotIn[] NotIn { get; set; }

        INotLike[] NotLike { get; set; }

        IEquals[] Equals { get; set; }

        INotEquals[] NotEquals { get; set; }
    }
}
