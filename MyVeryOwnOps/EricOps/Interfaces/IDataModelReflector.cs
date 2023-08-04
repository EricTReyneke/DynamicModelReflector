using System.Collections.Generic;

namespace DataModelReflector.Interfaces
{
    public interface IDataModelReflector
    {
        /// <summary>
        /// Sets a Specified Poko data model to all the data related to that data Model in the Database.
        /// </summary>
        /// <typeparam name="TModel">Specified Poko class Type.</typeparam>
        /// <returns>IEnumerable of all the data in that database relating to the name of the Type in the Database.</returns>
        IEnumerable<TModel> Load<TModel>(IConditions conditions = null) where TModel : class, new();
    }
}
