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
            typeof(TModel).GetProperty(columnName).PropertyType == typeof(string) ? $"'{value}'" : $"{value}";
        #endregion
    }
}
