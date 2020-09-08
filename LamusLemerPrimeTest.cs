using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucasLemusPrimeTest
{
    class Program
    {
        public static LamusLemer lamusLemer;


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(IsMersennePrime(n));
        }
        public static bool IsMersennePrime(int n)
        {
            double twoPowP = n + 1;
            int p = 0;
            while (twoPowP % 2 == 0 && twoPowP != 1)
            {
                twoPowP /= 2.0;
                p++;
            }
            if (twoPowP != 1)
            {
                Console.WriteLine("Not all conditions are met:");
                Console.WriteLine("Given number has to be equal to (2^p - 1) for a specific prime number p");
            }
            if (!IsPrime(p))
            {
                Console.WriteLine("Not all conditions are met:");
                Console.WriteLine("Given number has to be equal to (2^p - 1) for a specific prime number p");
                Console.WriteLine("In the number you gave, p is not a prime number");
                return false;
            }
            return IsMersennePrimeHelp(n, p);
        }
        private static bool IsMersennePrimeHelp(int n, int p)
        {
            lamusLemer = new LamusLemer(p - 1); // lamusLemer = new LamusLemer(p - 1, n);
            if (lamusLemer[p - 1] % n == 0) // if (lamusLemer[p - 1] == 0)
                return true;
            return false;
        }
        public static bool IsPrime(long n)
        { // Trial Division Primality Test
            if (n % 2 == 0)
                return n == 2;

            // not necessary but nice to know
            bool b1 = (n - 1) % 6 == 0;
            bool b2 = (n + 1) % 6 == 0;
            if (n != 3 && !b1 && !b2)
                return false;
            // not necessary but nice to know

            for (long i = 3; i <= Math.Floor(Math.Sqrt(n)) + 1; i += 2)
                if (n % i == 0)
                    return false;
            return true;
        }
        public static bool FermatPrimalityTest(int n)
        {
            if (n == 2)
                return true;

            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                int a = rnd.Next(2, n - 1);
                if (GCD(n, a) != 1)
                    return false;

                double power = Math.Pow(a, n - 1);
                if (power % n != 1)
                    return false;
            }
            return true;
        }
        public static int GCD(int x, int y)
        {
            int dividend = Math.Max(x, y);
            int divisor = Math.Min(x, y);
            int remainder = 1;
            while (remainder != 0)
            {
                remainder = dividend % divisor;
                divisor = remainder;
                dividend = divisor;
            }

            return divisor;
        }
    }
    public class LamusLemer
    {
        private readonly List<int> sequence;

        public int this[int index]
        {
            get { return sequence[index]; }
        }

        public LamusLemer(int lastPosition)
        {
            sequence = new List<int>() { 0, 4 };
            int next = 0;
            for (int i = 2; i < lastPosition; i++)
            {
                next = (int)(Math.Pow(sequence[i - 1], 2) - 2);
                sequence.Add(next);
            }
        }

        public LamusLemer(int lastPosition, int num)
        { // assuming num = (2^p - 1) given a prime number p
            sequence = new List<int>() { 0, 4 };
            int next = 0;
            for (int i = 2; i < lastPosition; i++)
            {
                next = (int)(Math.Pow(sequence[i - 1], 2) - 2);
                sequence.Add(next % num);
            }
        }
    }
}

//public static bool IsMersennePrime(int n)
//{

//    List<int> A = new List<int>();
//    A.Add(0);
//    A.Add(4); //A[1] =4;
//    int twoPowP = n + 1;
//    int p = 0;
//    while (twoPowP != 1)
//    {
//        twoPowP /= 2;
//        p++;
//    }
//    if (!p.IsPrime())
//        return false;
//    for (int i = 2; i < p; i++)
//        A.Add((int)(Math.Pow(A[i - 1], 2) - 2));
//    if (A[p - 1] % n == 0)
//        return true;
//    return false;

//}
