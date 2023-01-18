using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Prints the firt 5 prime numbers from the Fibonacci series
 * */
namespace ConsoleApp1
{
    internal class Program
    {
        // IEnumerable<T> is an implementation of the Iterator Pattern in C#.
        private static IEnumerable<int> GetFibonacci()
        {
            int previousVal1 = 0, previousVal2 = 1;

            while (true)
            {
                int nextVal = previousVal1 + previousVal2;
                previousVal1 = previousVal2;
                previousVal2 = nextVal;
                yield return nextVal;
            }
        }

        static void Main(string[] args)
        {
            IEnumerable<int> primes = GetFibonacci().Where(
                n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(divisor => n % divisor != 0));

            foreach (int num in primes.Take(5))
            {
                Console.WriteLine(num);
            }
        }
    }
}
