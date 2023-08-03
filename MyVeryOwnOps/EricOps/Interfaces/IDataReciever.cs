using System.Data;

namespace EricOps.Interfaces
{
    public interface IDataReciever
    {
        DataTable RetrieveTableData(string selectStatmentString);
    }
}
