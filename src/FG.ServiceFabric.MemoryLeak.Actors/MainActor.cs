using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FG.ServiceFabric.Actors.Runtime;
using FG.ServiceFabric.Diagnostics;
using FG.ServiceFabric.MemoryLeak.Actors.Interfaces;
using Microsoft.ServiceFabric.Actors;
using ActorService = Microsoft.ServiceFabric.Actors.Runtime.ActorService;

namespace FG.ServiceFabric.MemoryLeak.Actors
{
    public class MainActor : ActorBase, IMainActor
    {
        public MainActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
        }
        
        public async Task<int[]> GetSomeNumbers()
        {
            var tasks = new List<Task<int>>();

            for (var i = 0; i < 5; ++i)
            {
                var proxy = ActorProxyFactory.CreateActorProxy<INumberActor>(new ActorId(Guid.NewGuid()));

                tasks.Add(proxy.GetANumber());
            }

            return (await Task.WhenAll(tasks)).ToArray();
        }
    }
}