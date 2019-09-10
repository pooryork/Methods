using System;
using System.Text;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            double b = 2;
            double h = 0.1;
            double e = 0.0001;
            double prev1 = 0, prev2 = 0, prev3 = 0;
            StringBuilder x_first = new StringBuilder(), sum_x_first = new StringBuilder(),
                f1 = new StringBuilder(), f2 = new StringBuilder(), f3 = new StringBuilder();
            for (double x = a; x <= b; x += h) //Выбираем x из заданного отрезка
            {
                x_first.Append(x + " | ");
                double sum = 0; // m - оцередное слагаемое
                double k = 0; // k - счётчик цикла; 
                double f0 = 1;
                while (Math.Abs(f0) > e)
                {
                    prev3 = prev2;
                    prev2 = prev1;
                    double q = -Math.Pow(x, 4) / ((2 * k + 1)*(2 * k + 2));
                    f0 *= q;
                    sum += f0;
                    prev1 = f0;      
                    k++;
                    
                }
                if (k > 1)
                {
                    //Console.WriteLine("{0}, {1}, {2}", prev1, prev2, prev3);
                    double ff1 = (prev1 - prev2) / h;
                    f1.Append(Math.Round(ff1, 5) + " | ");
                    double ff2 = (prev2 - prev3) / h;
                    f2.Append(Math.Round(ff2, 5) + " | ");
                    double ff3 = (prev1 - prev3) / (2*h);
                    f3.Append(Math.Round(ff3, 5) + " | ");

                }
                sum_x_first.Append(Math.Round(sum, 5) + " | ");
            }
            Console.WriteLine(x_first);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(sum_x_first);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(f1);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(f2);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(f3);

        }
        static double Factorial(double x)
        {
            return (x == 0) ? 1 : x * Factorial(x - 1);
        }

    }
}
