using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace FG.ServiceFabric.MemoryLeak.Actors.Interfaces
{
    public interface INumberActor : IActor
    {
        Task<int> GetANumber();
    }
}