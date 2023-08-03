﻿using DataModelReflector.Interfaces;
using DataModelReflector.SqlConditions;
using EricOps.Interfaces;

namespace DataModelReflector.Conditions
{
    public struct SqlConditions : IConditions
    {
        public IBetween[] Between { get; set; }
        public IIn[] In { get; set; }
        public ILike[] Like { get; set; }
        public INotIn[] NotIn { get; set; }
        public INotLike[] NotLike { get; set; }
        public IEquals[] Equals { get; set; }
        public INotEquals[] NotEquals { get; set; }
        public IOrConditions[] OrConditions { get; set; }
    }
}