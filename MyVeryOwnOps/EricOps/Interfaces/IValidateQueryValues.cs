namespace EricOps.Interfaces
{
    public interface IValidateQueryValues
    {
        /// <summary>
        /// Retrieves the values in a array and enters them into () brackets.
        /// </summary>
        /// <typeparam name="TModel">POCO model type.</typeparam>
        /// <param name="columnName">Column name/Property Name to do the type validation against.</param>
        /// <param name="value">Value which the '' might encapsulate.</param>
        /// <returns>Values which will be inside () brackets.</returns>
        string RetrieveValuesInArray<TModel>(string columnName, object[] values);

        /// <summary>
        /// Validates the property type to add '' when nessasary.
        /// </summary>
        /// <typeparam name="TModel">POCO model type.</typeparam>
        /// <param name="columnName">Column name/Property Name to do the type validation against.</param>
        /// <param name="value">Value which the '' might encapsulate.</param>
        /// <returns>Value which the '' might encapsulate.</returns>
        string ValidateTypeForQuotations<TModel>(string columnName, string value);
    }
}
