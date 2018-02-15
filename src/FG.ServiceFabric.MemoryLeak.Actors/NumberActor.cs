using System;
using System.Threading.Tasks;
using FG.ServiceFabric.Actors.Runtime;
using FG.ServiceFabric.MemoryLeak.Actors.Interfaces;
using Microsoft.ServiceFabric.Actors;
using ActorService = Microsoft.ServiceFabric.Actors.Runtime.ActorService;

namespace FG.ServiceFabric.MemoryLeak.Actors
{
    public class NumberActor : ActorBase, INumberActor
    {
        private Random _random;


        public NumberActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
            this._random = new Random(actorId.GetHashCode());
        }

        public Task<int> GetANumber()
        {
            return Task.FromResult(this._random.Next());
        }
    }
}