using System;
using System.Text;

namespace EricOps.BaseClass
{
    public class ValidateQueryValues
    {
        #region Fields
        public Type dataModel; 
        #endregion

        #region Public Methods
        public string RetrieveValuesInArray(string columnName, object[] values, Type dataModelType)
        {
            try
            {
                StringBuilder valuesInArray = new StringBuilder();
                foreach (object value in values)
                    valuesInArray.Append(ValidateTypeForQuotations(columnName, value.ToString(), dataModelType));

                string arrayValues = valuesInArray.ToString().Trim();

                return arrayValues.Substring(0, arrayValues.Length - 1);
            }
            catch
            {
                return null;
            }
        }

        public string ValidateTypeForQuotations(string columnName, string value, Type dataModelType)
        {
            try
            {
                return dataModelType.GetProperty(columnName).GetType() == typeof(string) ? $"'{value}', " : value;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
