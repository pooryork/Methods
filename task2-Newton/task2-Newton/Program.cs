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

            Dictionary<int, List<double>> list = new Dictionary<int, List<double>>();

            list.Add(0, mas_y);
            int n = 1;
            int count = mas_x.Count;
            int h = 0;
            for (int i = 0; i < count; i++)
            {
                h++;
                List<double> lst = new List<double>();
                for (int j = 0; j < count - n; j++)
                {
                    double element = (list[i][j + 1] - list[i][j]) / (mas_x[j + h] - mas_x[j]);
                    lst.Add(System.Math.Round(element, 2));
                }
                list.Add(i + 1, lst);
                n++;
            }
            foreach (KeyValuePair<int, List<double>> keyValue in list)
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
                Console.WriteLine(System.Math.Round(NewtonFunc(mas_x, newton, x, list, count), 4));
            }
        }
        public static double NewtonFunc(List<double> mas_x, double newton, double x, Dictionary<int, List<double>> list, int count)
        {
            for (int i = 1; i < count; i++)
            {
                double func = 1;
                for (int j = 0; j < i; j++)
                {
                    func *= (x - mas_x[j]);
                }
                newton += (func * list[i][0]);
            }
            return newton;
        }

    }
}

