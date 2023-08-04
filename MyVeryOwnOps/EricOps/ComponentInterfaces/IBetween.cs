using EricOps.Interfaces;

namespace DataModelReflector.Interfaces
{
    public interface IBetween : IQueryCreator
    {
        string ColumnName { get; set; }
        string Value1 { get; set; }
        string Value2 { get; set; }
    }
}
