using DataModelReflector.Conditions;
using DataModelReflector.Data.Models;
using DataModelReflector.DataModelReflectors;
using DataModelReflector.Interfaces;
using DataModelReflector.SqlConditions;
using EricOps.DALs;
using EricOps.Interfaces;
using EricOps.QueryBuilders;
using EricOps.SqlConditions;

namespace DataModelReflectorConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDataAccess dataReciever = new SqlDataAccess();
            IQueryBuilder queryBuilder = new SqlQueryBuilder();
            IDataModelReflector reflector = new SqlDataModelReflector(dataReciever, queryBuilder);

            IConditions sqlConditions = new SqlConditions()
            {
                InsertConditions = new SqlInsertConditions()
                {
                    Inserts = new SqlInsert[]
                    {
                        new SqlInsert("Category_Name", "0/30 Seuns"),
                        new SqlInsert("Tournament_Id", "4")
                    }
                },
                AndConditions = new SqlAndConditions()
                {
                    Equals = new SqlEquals[]
                    {
                        new SqlEquals("Tournament_Id", "1")
                    }
                }                
            };

             reflector.Insert<Categories>(sqlConditions);
        }
    }
}