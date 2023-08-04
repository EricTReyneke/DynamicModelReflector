using System;
using System.Text;

namespace EricOps.BaseClass
{
    public class ValidateQueryValues
    {
        #region Public Methods
        public string RetrieveValuesInArray(string columnName, object[] values, Type dataModelType)
        {
            try
            {
                StringBuilder valuesInArray = new StringBuilder();
                foreach (object value in values)
                    valuesInArray.Append(ValidateTypeForQuotations(columnName, value.ToString(), dataModelType) + ", ");

                return valuesInArray.ToString().Trim().TrimEnd(',');
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public string ValidateTypeForQuotations(string columnName, string value, Type dataModelType)
        {
            try
            {
                return dataModelType.GetProperty(columnName).GetType() == typeof(string) ? $"'{value}'" : $"{value}";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion
    }
}
