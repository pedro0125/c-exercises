using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Prints the firt 10 prime numbers from the Fibonacci series
 * */
namespace ConsoleApp1
{
    internal class fibonacci1
    {
        // IEnumerable<T> is an implementation of the Iterator Pattern in C#.
        private static IEnumerable<int> GetFibonacci()
        {
            int previousVal1 = 0, previousVal2 = 1;
            yield return previousVal1;
            yield return previousVal2;

            while (true)
            {
                int nextVal = previousVal1 + previousVal2;
                previousVal1 = previousVal2;
                previousVal2 = nextVal;
                yield return nextVal;
            }
        }

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

        static void Main(string[] args)
        {
            IEnumerable<int> primes = GetFibonacci().Where(IsPrime);

            foreach (int num in primes.Take(10))
            {
                Console.WriteLine(num);
            }
        }
    }
}
