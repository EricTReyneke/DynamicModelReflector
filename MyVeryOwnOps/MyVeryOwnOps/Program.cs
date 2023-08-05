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
                AndConditions = new SqlAndConditions()
                {
                    Equals = new SqlEquals[]
                    {
                        new SqlEquals("Tournament_Pits_Playable", "''")
                    }
                },
                OrConditions = new SqlOrConditions()
                {
                    Equals = new SqlEquals[]
                    {
                        new SqlEquals("Tournament_Id", "1"),
                        new SqlEquals("Tournament_Id", "2"),
                        new SqlEquals("Tournament_Id", "4")
                    }
                }
            };

            IEnumerable<Tournaments> tournaments = reflector.Load<Tournaments>(sqlConditions);
        }
    }
}