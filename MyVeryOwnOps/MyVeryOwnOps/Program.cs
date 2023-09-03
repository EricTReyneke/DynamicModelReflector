using DataModelReflector.Conditions;
using DataModelReflector.Data.Models;
using DataModelReflector.DataModelReflectors;
using DataModelReflector.Interfaces;
using DataModelReflector.SqlConditions;
using EricOps.DALs;
using EricOps.Interfaces;
using EricOps.QueryBuilders;
using EricOps.SqlConditions;
using System.Xml.Linq;

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

//Create Table Category(
//Id Int Primary Key Identity(1, 1),
//Name VarChar(50) Not Null,
//Level Int check(Level > 0 And Level <= 3),
//NumberOfPlayers Int,
//Date DateTime)

//Insert Into Category (Name, Level, NumberOfPlayers, Date)
//Values('C1', 1, 40, '2008-11-11'),
//('C2', 2, 12, '2008-11-4'),
//('C3', 2, 23, '2008-11-7'),
//('C4', 3, 53, '2008-11-1'),
//('C4', 3, 2, '2008-11-12')