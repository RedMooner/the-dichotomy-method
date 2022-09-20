using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double e = 0.0001;
            double eFound;
            double c;

            double a = -1;
            double b = -0;

            int count = 0;


            do
            {
                c = CalculateAverageSum(a, b);
                eFound = CalculateE(a, b);
                CalculateIteration(ref a, c, ref b);
                count++;
            }
            while (e < eFound);
            Console.WriteLine("Кол-во итераций: " + count);
            Console.WriteLine("x = " + Math.Round((a + b) / 2, 4));
            Console.ReadLine();
        }

        private static double CalculateAverageSum(double a, double b)
        {
            var avgSum = Math.Round((a + b) / 2, 4);
            Console.WriteLine($"\t({a} + {b}) / 2 = {avgSum}");
            return avgSum;
        }

        private static double CalculateE(double a, double b)
        {
            var e = (b - a) / 2;
            if (e < 0.0001)
            {
                Console.WriteLine($"\tE = (b - a) / 2 = {e} < 0.0001");
            }
            else if (e < 0.0002)
            {
                Console.WriteLine($"\tE = (b - a) / 2 = {e} > 0.0001");
            }

            return e;
        }

        private static void CalculateIteration(ref double a, double c, ref double b)
        {
            var fa = 2 * Math.Pow(a, 3) - 3 * Math.Pow(a,2) + 6 * a + 2;
            var fb = 2 * Math.Pow(b, 3) - 3 * Math.Pow(b, 2) + 6 *b + 2; 
            var fc = 2 * Math.Pow(c, 3) - 3 * Math.Pow(c, 2) + 6 * c + 2; 
            bool fafc = (fa * fc) < 0;
            bool fcfb = (fc * fb) < 0;

            if (fafc)
            {
                b = c;
                Console.WriteLine($"\tf(a)*f(c) < 0");
                Console.WriteLine($"\tf(c)*f(b) > 0");
            }
            else
            {
                a = c;
                Console.WriteLine($"\tf(a)*f(c) > 0");
                Console.WriteLine($"\tf(c)*f(b) < 0");
            }
            Console.WriteLine("fa = " + Math.Round(fa,6) + " fc = " + Math.Round(fc,6) );

            Console.WriteLine("\n");
        }
    }
}
