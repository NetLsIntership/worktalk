using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using WorkTalk.Domain.Entities;
using WorkTalk.Domain.Implementation;

namespace ForTesting
{
    public class ConcurrentBagSampleService
    {
        public ConcurrentBag<int> _integerBag = new ConcurrentBag<int>();
        

        public void RunConcurrentBagSample()
        {
            FillUpBag(1000);
            Task readerOne = Task.Run(() => GetFromBag());
            Task readerTwo = Task.Run(() => GetFromBag());
            Task readerThree = Task.Run(() => GetFromBag());
            Task readerFour = Task.Run(() => GetFromBag());
            Task.WaitAll(readerOne, readerTwo, readerThree, readerFour);
        }

        public void FillUpBag(int max)
        {
            for (int i = 0; i <= max; i++)
            {
                _integerBag.Add(i);
            }
        }

        public void GetFromBag()
        {
            int res;
            bool success = _integerBag.TryTake(out res);
            while (success)
            {
                Console.WriteLine(res);
                success = _integerBag.TryTake(out res);

            }
        }
    }
    // Declaration of a delegate
    public delegate void SimpleDelegate(string param);
    public class DelegatesExample
    {
        public static void TestMethod(string param)
        {
            Console.WriteLine("I was called by a delegate.");
            Console.WriteLine("I got parameter {0}.", param);
        }
        public static void Main()
        {
            ConcurrentBagSampleService temp = new ConcurrentBagSampleService();
            temp.FillUpBag(1000);
            temp.RunConcurrentBagSample();
            temp._integerBag.
        }
    }
}
