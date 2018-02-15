using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FG.ServiceFabric.MemoryLeak.Actors.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace FG.ServiceFabric.MemoryLeak.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<int>> Get()
        {
            var proxy = ActorProxy.Create<IMainActor>(new ActorId(Guid.NewGuid()));
            return await proxy.GetSomeNumbers();
        }
    }
}
