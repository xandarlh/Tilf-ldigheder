using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Threading;
using System.Diagnostics;

namespace Randoms
{
    class Program
    {
        static Random random = new Random();
        static RNGCryptoServiceProvider RNGCrypto = new RNGCryptoServiceProvider();
        static void Random()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                int value = random.Next(0, 1000);
            }
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;

            Console.WriteLine("Generated 100000 numbers in: {0} with random", timeSpan);
        }
        static void RNG()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            byte[] data = new byte[4];
            for (int i = 0; i < 100000; i++)
            {
                RNGCrypto.GetBytes(data);
                int value = BitConverter.ToInt32(data, 0);
            }
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;

            Console.WriteLine("Generated 100000 numbers in: {0} with crypto", timeSpan);
        }
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Random);
            thread1.Start();
            Thread thread2 = new Thread(RNG);
            thread2.Start();
            Console.Read();

        }
    }
}
