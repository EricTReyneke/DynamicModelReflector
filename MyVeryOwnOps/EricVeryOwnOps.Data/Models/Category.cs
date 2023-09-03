using System;

namespace DataModelReflector.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Level { get; set; }
        public int? NumberOfPlayers { get; set; }
        public DateTime? Date { get; set; }
    }
}