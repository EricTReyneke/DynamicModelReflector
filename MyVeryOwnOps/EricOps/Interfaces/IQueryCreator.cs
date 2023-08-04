using System;

namespace EricOps.Interfaces
{
    public interface IQueryCreator
    {
        string GenerateConditionString<TModel>();
    }
}
