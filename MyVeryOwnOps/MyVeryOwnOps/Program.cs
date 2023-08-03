using DataModelReflector.Conditions;
using DataModelReflector.Interfaces;
using DataModelReflector.DataModelReflectors;
using DataModelReflector.Data.Models;
using EricOps.Interfaces;
using EricOps.DataRecievers;
using EricOps.QueryBuilders;

namespace DataModelReflectorConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDataReciever dataReciever = new SqlDataReciever();
            IQueryBuilder queryBuilder = new SqlQueryBuilder();
            IDataModelReflector reflector = new SqlDataModelReflector(dataReciever, queryBuilder);

            IConditions conditions = new SqlConditions()
            {
                In = new SqlIn[]
                {
                    new SqlIn("Tournament_Id", new string[] { "1", "2" })
                }
                //OrConditions = new SqlConditions
                //{
                //    Equals = new S
                //}
            };

            IEnumerable<Tournaments> tournaments = reflector.Load<Tournaments>(conditions);
        }
    }
}