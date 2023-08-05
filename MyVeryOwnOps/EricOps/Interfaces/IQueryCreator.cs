using System;

namespace EricOps.Interfaces
{
    public interface IQueryCreator
    {
        /// <summary>
        /// Generates a conditional statment.
        /// </summary>
        /// <typeparam name="TModel">POCO model which would reflect the table in the database.</typeparam>
        /// <returns>Conditional statment</returns>
        string GenerateConditionString<TModel>();
    }
}
