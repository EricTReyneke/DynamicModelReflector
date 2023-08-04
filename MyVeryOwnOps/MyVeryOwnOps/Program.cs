using DataModelReflector.Conditions;
using DataModelReflector.Data.Models;
using DataModelReflector.DataModelReflectors;
using DataModelReflector.Interfaces;
using DataModelReflector.SqlConditions;
using EricOps.DataRecievers;
using EricOps.Interfaces;
using EricOps.QueryBuilders;
using EricOps.SqlConditions;

namespace DataModelReflectorConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDataReciever dataReciever = new SqlDataReciever();
            IQueryBuilder queryBuilder = new SqlQueryBuilder();
            IDataModelReflector reflector = new SqlDataModelReflector(dataReciever, queryBuilder);

            IConditions sqlConditions = new SqlConditions()
            {
                In = new SqlIn[]
                {
                    new SqlIn("Tournament_Id", new string[] { "1", "2" })
                },
                OrConditions = new SqlOrConditions[]
                {
                    new SqlOrConditions()
                    {
                        Conditions = new IConditions[]
                        {
                            new SqlConditions
                            {
                                Equals = new SqlEquals[]
                                {
                                    new SqlEquals("Tournament_Id", "3")
                                },
                                Between = new SqlBetween[]
                                {
                                    new SqlBetween("Tournament_Pits_Playable", "30", "50")
                                }
                            }
                        }
                    }
                }
            };

            IEnumerable<Tournaments> tournaments = reflector.Load<Tournaments>(sqlConditions);
        }
    }
}