using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace FG.ServiceFabric.MemoryLeak.Actors.Interfaces
{
    public interface IMainActor : IActor
    {
        Task<int[]> GetSomeNumbers();
    }
}