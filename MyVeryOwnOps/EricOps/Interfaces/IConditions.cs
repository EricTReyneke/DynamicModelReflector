﻿using DataModelReflector.SqlConditions;
using EricOps.Interfaces;

namespace DataModelReflector.Interfaces
{
    public interface IConditions
    {
        IBetween[] Between { get; set; }

        IIn[] In { get; set; }

        ILike[] Like { get; set; }

        INotIn[] NotIn { get; set; }

        INotLike[] NotLike { get; set; }

        IEquals[] Equals { get; set; }

        INotEquals[] NotEquals { get; set; }

        IOrConditions[] OrConditions { get; set; }
    }
}
