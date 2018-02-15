using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FG.ServiceFabric.MemoryLeak.LoadTester
{
    public class Worker
    {
        private readonly ConcurrentQueue<Job> _jobQueue;
        private readonly TaskCompletionSource<bool> _taskCompletationSource;

        private static readonly HttpClient _httpClient = new HttpClient();
        
        public Worker(ConcurrentQueue<Job> jobQueue)
        {
            _jobQueue = jobQueue;
            _taskCompletationSource = new TaskCompletionSource<bool>();
        }

        public async Task StartAsync()
        {
            while (!_jobQueue.IsEmpty)
            {

                if (_jobQueue.TryDequeue(out var job))
                {
                    await _httpClient.GetAsync("http://localhost:8377/api/values");
                }
            }
        }   
    }
}