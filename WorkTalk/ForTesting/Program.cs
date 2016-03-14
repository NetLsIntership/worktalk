using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using WorkTalk.Domain.Entities;
using WorkTalk.Domain.Implementation;

namespace ForTesting
{
    class Program
    {
        static void Main()
        {
            var client = new RedisClient("localhost");
            client.FlushDb();
        }
    }
}
