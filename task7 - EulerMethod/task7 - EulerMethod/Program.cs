using System;

namespace task7___EulerMethod
{
    class Program
    {
        public static double calculate_y(double x, int V)
        {
            return Math.Pow(x, 3) + V*Math.Pow(x, 2);
        }
        static void Main(string[] args)
        {

            double a = 0;
            int V = 7;
            int n = 10;
            double h = 0.1;
            double[] x = new double[n + 1];
            double[] y = new double[n + 1];
            x[0] = 0;
            y[0] = 0;
            for (int i = 1; i <= n; i++)
            {   
                y[i] = y[i - 1] + h * (3 * Math.Pow(x[i - 1], 2) + 2 *V * x[i - 1] + y[i - 1] - Math.Pow(x[i-1], 3) - V * Math.Pow(x[i-1], 2));
                a += h;
                x[i] = a;
            }
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("x={0}  y={1} f(x)={2}", x[i], y[i], calculate_y(x[i], V));
            }
            Console.ReadLine();
        }
    }
}

