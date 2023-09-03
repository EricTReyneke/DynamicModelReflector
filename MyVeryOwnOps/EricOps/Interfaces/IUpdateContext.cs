using EricOps.ComponentInterfaces;

namespace EricOps.Interfaces
{
    public interface IUpdateContext
    {
        IUpdate[] Updates { get; set; }
    }
}