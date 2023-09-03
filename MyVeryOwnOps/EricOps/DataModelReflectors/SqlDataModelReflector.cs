using DataModelReflector.Interfaces;
using EricOps.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DataModelReflector.DataModelReflectors
{
    public class SqlDataModelReflector : IDataModelReflector
    {
        #region Fields
        private IDataAccess _dataAccess;
        private IQueryBuilder _queryBuilder;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a SqlDataModelReflector which recieves the IDataReciever and IQueryBuilder.
        /// </summary>
        public SqlDataModelReflector(IDataAccess dataReciever, IQueryBuilder queryBuilder)
        {
            _dataAccess = dataReciever;
            _queryBuilder = queryBuilder;
        }
        #endregion

        #region Public Methods
        public IEnumerable<TModel> Load<TModel>(IAndOrConditions conditions = null) where TModel : class, new()
        {
            try
            {
                return MapProperties<TModel>(_dataAccess.RetrieveTableData(_queryBuilder.LoadQueryBuilder<TModel>(conditions)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public void Delete<TModel>(IAndOrConditions conditions = null) where TModel : class, new()
        {
            try
            {
                _dataAccess.DeleteTableData(_queryBuilder.DeleteQueryBuilder<TModel>(conditions));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Update<TModel>(IUpdateConditions updateConditions = null) where TModel : class, new()
        {
            try
            {
                _dataAccess.UpdateTableData(_queryBuilder.UpdateQueryBuilder<TModel>(updateConditions));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Insert<TModel>(IInsertConditions insertConditions = null) where TModel : class, new()
        {
            try
            {
                _dataAccess.InsertTableData(_queryBuilder.InsertQueryBuilder<TModel>(insertConditions));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Mapes Properties in the POCO model with the data recieved from the database.
        /// </summary>
        /// <typeparam name="TModel">Poco model which refects the table in the database.</typeparam>
        /// <param name="tableData">DataTable which holds the data recieved from the Database.</param>
        /// <returns>List of Objects.</returns>
        private IEnumerable<TModel> MapProperties<TModel>(DataTable tableData) where TModel : class, new()
        {
            ICollection<TModel> dataModels = new List<TModel>();
            foreach (DataRow rowData in tableData.Rows)
            {
                TModel setDataModel = new TModel();

                foreach (PropertyInfo propertyInfo in typeof(TModel).GetProperties())
                    propertyInfo.SetValue(setDataModel, TypeConversion(rowData[propertyInfo.Name].ToString(), propertyInfo.PropertyType));

                dataModels.Add(setDataModel);
            }

            return dataModels;
        }

        /// <summary>
        /// Converts the string value into the propertyType provided.
        /// </summary>
        /// <param name="propertyValue">Value which would be converted into the type provided.</param>
        /// <param name="propertyType">Poco Property type.</param>
        /// <returns>Object which would be the same type as the propertyType provided.</returns>
        private object TypeConversion(string propertyValue, Type propertyType)
        {
            if (string.IsNullOrEmpty(propertyValue))
                return null;

            if (Nullable.GetUnderlyingType(propertyType) != null)
                propertyType = Nullable.GetUnderlyingType(propertyType);

            return Convert.ChangeType(propertyValue, propertyType);
        }
        #endregion
    }
}