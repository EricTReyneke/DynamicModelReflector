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

            IAndOrConditions sqlAdOrConditions = new SqlAndOrConditions()
            {
                AndConditions = new SqlAndConditions()
                {
                    IsNulls = new SqlIsNull[]
                    {
                        new SqlIsNull("Level")
                    },
                    IsNotNulls = new SqlIsNotNull[] 
                    {
                        new SqlIsNotNull("Name")
                    }
                }
            };

            IEnumerable<Category> categories = reflector.Load<Category>(sqlAdOrConditions);
        }
    }
}