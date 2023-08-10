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

            IConditions deleteTournament = new SqlConditions()
            {
                AndConditions = new SqlAndConditions()
                {
                    Equals = new SqlEquals[]
                    {
                        new SqlEquals("Tournament_Id", "8")
                    }
                }
            };

            reflector.Delete<Tournaments>(deleteTournament);

            IConditions sqlConditions = new SqlConditions()
            {
                InsertConditions = new SqlInsertConditions()
                {
                    Inserts = new SqlInsert[]
                    {
                        new SqlInsert("Tournament_Name", "Bushi Swart 2023"),
                        new SqlInsert("Tournament_Location", "Pretoria"),
                        new SqlInsert("Tournament_Address", "Sunny Road"),
                        new SqlInsert("Tournament_Type", "Day"),
                        new SqlInsert("Tournament_Start_Date", "2022-01-14"),
                        new SqlInsert("Tournament_End_Date", "2022-01-14"),
                        new SqlInsert("Tournament_Extension", "True"),
                        new SqlInsert("Tournament_Duration", ""),
                        new SqlInsert("Tournament_Pits_Playable", "40"),
                        new SqlInsert("Tournament_State", ""),
                        new SqlInsert("Tournament_Age_Group", "0/30"),
                        new SqlInsert("Tournament_Blocks", "")
                    }
                }
            };

            reflector.Insert<Tournaments>(sqlConditions);
        }
    }
}