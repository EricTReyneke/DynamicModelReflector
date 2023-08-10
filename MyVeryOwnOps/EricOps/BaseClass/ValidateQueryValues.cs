using EricOps.Interfaces;
using System;
using System.Text;

namespace EricOps.BaseClass
{
    public class ValidateQueryValues : IValidateQueryValues
    {
        #region Public Methods
        public string RetrieveValuesInArray<TModel>(string columnName, object[] values)
        {
            try
            {
                StringBuilder valuesInArray = new StringBuilder();
                foreach (object value in values)
                    valuesInArray.Append(ValidateTypeForQuotations<TModel>(columnName, value.ToString()) + ", ");

                return valuesInArray.ToString().Trim().TrimEnd(',');
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public string ValidateTypeForQuotations<TModel>(string columnName, string value) =>
            NeedsQuotes(ref value, typeof(TModel).GetProperty(columnName).PropertyType) ? $"'{value}'" : $"{value}";
        #endregion

        #region Private Methods
        /// <summary>
        /// Validates the DataType of the property and and returns true or false if single quotes are nessasary.
        /// </summary>
        /// <param name="propertyType">Specified property type.</param>
        /// <returns></returns>
        private bool NeedsQuotes(ref string value, Type propertyType)
        {
            if(ConvertToNull(ref value))
                return false;

            switch (Nullable.GetUnderlyingType(propertyType)?.FullName ?? propertyType.FullName)
            {
                case "System.String":
                case "System.DateTime":
                case "System.Char":
                case "System.TimeSpan":
                case "System.Guid":
                    return true;
                case "System.Boolean":
                    ConvertBoolean(ref value);
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Converts boolean values into SQL bit values.
        /// </summary>
        /// <param name="value">reference type of the value string.</param>
        private void ConvertBoolean(ref string value)
        {
            if (value.ToLower() == "true")
                value = "1";
            else
                value = "0";
        }

        /// <summary>
        /// Validates if the value is string.empty. If true then the string will be converted to Null.
        /// </summary>
        /// <param name="value">reference type of the value string.</param>
        /// <returns>If the value string is string.empty or not.</returns>
        private bool ConvertToNull(ref string value)
        {
            if (value == string.Empty)
            {
                value = "Null";
                return true;
            }

            return false;
        }
        #endregion
    }
}