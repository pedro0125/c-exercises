using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class delegates
    {

        private delegate void ReceivesInt(int i);

        private static event ReceivesInt? RandomEvent;

        private static bool IsPrime(int x)
        {
            if (x < 2)
                return false;
            else if (x == 2)
                return true;
            else if (x % 2 == 0)
                return false;

            return Enumerable.Range(2, (int)Math.Sqrt(x) - 1).All(divisor => x % divisor != 0);
        }

        private static void PrintIfPrime(int x)
        {
            if (IsPrime(x))
                Console.WriteLine($"{x} is prime");
        }

        private static void PrintIfDivisableByThree(int x)
        {
            if (x % 3 == 0)
                Console.WriteLine($"{x} is divisable by 3");
        }

        static void Main(string[] args)
        {
            RandomEvent += PrintIfPrime;
            RandomEvent += PrintIfDivisableByThree;

            Random rng = new Random();
            Task.Run(async () =>
            {
                while (true)
                {
                    RandomEvent?.Invoke(rng.Next());
                    await Task.Delay(1000);
                }
            });

            Console.ReadLine();
        }
    }
}
