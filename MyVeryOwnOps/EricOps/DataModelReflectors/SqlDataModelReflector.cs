using DataModelReflector.Interfaces;
using EricOps.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace DataModelReflector.DataModelReflectors
{
    public class SqlDataModelReflector : IDataModelReflector
    {
        #region Fields
        private string _tableName;
        private IDataReciever _dataReciever;
        private IQueryBuilder _queryBuilder;
        #endregion

        #region Constructors
        public SqlDataModelReflector(IDataReciever dataReciever, IQueryBuilder queryBuilder)
        {
            _dataReciever = dataReciever;
            _queryBuilder = queryBuilder;
        }
        #endregion

        #region Public Methods
        public IEnumerable<TModel> Load<TModel>(IConditions conditions = null) where TModel : class, new()
        {
            TModel dataModel = new TModel();
            _tableName = dataModel.GetType().Name;

            try
            {
                return MapColumns<TModel>(_dataReciever.RetrieveTableData(_queryBuilder.BuildQueryStatement<TModel>(conditions)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        #endregion

        #region Private Methods
        private IEnumerable<TModel> MapColumns<TModel>(DataTable tableData)
        {
            ICollection<TModel> dataModels = new List<TModel>();
            foreach (DataRow rowData in tableData.Rows)
            {
                TModel setDataModel = (TModel)Activator.CreateInstance(typeof(TModel));

                foreach (PropertyInfo propertyInfo in typeof(TModel).GetProperties())
                    propertyInfo.SetValue(setDataModel, TypeConversion(rowData[propertyInfo.Name].ToString(), propertyInfo.PropertyType));

                dataModels.Add(setDataModel);
            }

            return dataModels;
        }

        private object TypeConversion(string propertyValue, Type propertyType)
        {
            if (propertyType == typeof(int) && string.IsNullOrEmpty(propertyValue))
                return 0;

            if (Nullable.GetUnderlyingType(propertyType) != null)
                propertyType = Nullable.GetUnderlyingType(propertyType);

            return Convert.ChangeType(propertyValue, propertyType);
        }
        #endregion
    }
}
