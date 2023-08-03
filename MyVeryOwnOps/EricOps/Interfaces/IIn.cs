﻿using EricOps.Interfaces;

namespace DataModelReflector.Interfaces
{
    public interface IIn : IQueryCreator
    {
        string ColumnName { get; set; }
        string[] Values { get; set; }
    }
}