using DataModelReflector.Interfaces;
using DataModelReflector.SqlConditions;
using EricOps.ComponentInterfaces;
using EricOps.Interfaces;

namespace EricOps.SqlConditions
{
    public class SqlAndConditions : IAndConditions
    {
        public IBetween[] Between { get; set; }

        public IIn[] In { get; set; }

        public ILike[] Like { get; set; }

        public INotIn[] NotIn { get; set; }

        public INotLike[] NotLike { get; set; }

        public IEquals[] Equals { get; set; }

        public INotEquals[] NotEquals { get; set; }

        public IIsNull[] IsNulls { get; set; }

        public IIsNotNull[] IsNotNulls { get; set; }
    }
}