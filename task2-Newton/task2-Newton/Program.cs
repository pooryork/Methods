using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace task2_Newton
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> mas_x = new List<double> { 1, 2, 3, 4 };
            List<double> mas_y = new List<double> { 7, 28, 63, 112 };

            Dictionary<int, List<double>> dict = new Dictionary<int, List<double>>();

            dict.Add(0, mas_y);
            int n = 1;
            int count = mas_x.Count;
            int h = 0;
            for (int i = 0; i < count; i++)
            {
                h++;
                List<double> list = new List<double>();
                for (int j = 0; j < count - n; j++)
                {
                    double element = (dict[i][j + 1] - dict[i][j]) / (mas_x[j + h] - mas_x[j]);
                    list.Add(System.Math.Round(element, 2));
                }
                dict.Add(i + 1, list);
                n++;
            }
            foreach (KeyValuePair<int, List<double>> keyValue in dict)
            {

                foreach (double element in keyValue.Value)
                {
                    Console.Write(String.Format("{0,6}", element));
                }
                Console.WriteLine();
            }
            double newton = mas_y[0];
            for (int i = 0; i < count - 1; i++)
            {
                double x = (mas_x[i] + mas_x[i + 1]) / 2;
                Console.Write(x + " - ");
                Console.WriteLine(System.Math.Round(NewtonFunc(mas_x, newton, x, dict, count), 4));
            }
        }
        public static double NewtonFunc(List<double> mas_x, double newton, double x, Dictionary<int, List<double>> dict, int count)
        {
            for (int i = 1; i < count; i++)
            {
                double func = 1;
                for (int j = 0; j < i; j++)
                {
                    func *= (x - mas_x[j]);
                }
                newton += (func * dict[i][0]);
            }
            return newton;
        }

    }
}

