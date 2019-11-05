using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Math_task_5 {
    class Program
    {
        static int n;

        static void Main(string[] args) {

            FileStream file1 = new FileStream("input.txt", FileMode.Open); //создаем файловый поток

            string[] mas;
            double[] a;
            double[] b;
            double[] c;
            double[] d;

            //Считываем массив из файла

            using (var file = new StreamReader(file1)) {

                n = int.Parse(file.ReadLine());
                a = new double[n];
                b = new double[n];
                c = new double[n];
                d = new double[n];

                mas = (file.ReadLine()).Split(' ');

                for (int i = 0; i < n; i++) {

                    a[i] = double.Parse(mas[i]);

                }

                mas = (file.ReadLine()).Split(' ');

                for (int i = 0; i < n; i++) {

                    b[i] = float.Parse(mas[i]);

                }

                mas = (file.ReadLine()).Split(' ');

                for (int i = 0; i < n; i++) {

                    c[i] = float.Parse(mas[i]);

                }

                mas = (file.ReadLine()).Split(' ');

                for (int i = 0; i < n; i++) {

                    d[i] = float.Parse(mas[i]);

                }

            }

            PrintOne(a);
            PrintOne(b);
            PrintOne(c);
            PrintOne(d);

            double[] x = MethodSweeps(a, b, c, d);

            PrintOne(x);

        }

        public static double[] MethodSweeps(double[] a, double[] b, double[] c, double[] d) {

            //Метод прогонки
            double[] p = new double[n];
            double[] q = new double[n];

            for (int i = 0; i < n; i++)
            {
                p[i] = 0;
                q[i] = 0;
            }

            for (int i = 0; i < n; i++) {

                if (i==0)
                {
                    p[i] = (-1) * c[i] / b[i];
                    q[i] = d[i] / b[i];
                }
                else
                {
                    p[i] = (-1) * c[i] / (b[i] + a[i] * p[i-1]);
                    q[i] = (d[i] - a[i] * q[i-1]) / (b[i] + a[i] * p[i-1]);
                    Console.WriteLine("a={0}, b={1}, c={2}, d={3}", a[i], b[i], c[i], d[i]);
                }

                Console.WriteLine("{0}: p={1}, q={2}", i, p[i], q[i]);
                Console.WriteLine();

            }

            double[] x = new double[n];

            for (int i = n-1; i >= 0; i--) {

                if (i == n - 1)
                {
                    Console.WriteLine("{0}: {1}", i, q[i]);
                    x[i] = q[i];
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("{0}: {1}, {2}, {3}", i, p[i], x[i], q[i]);
                    x[i] = p[i] * x[i + 1] + q[i];
                    Console.WriteLine();
                }

            }
            Console.WriteLine("__________________________________________");

            return x;

        }

        public static void PrintOne(double[] a)

        {

            for (int i = 0; i < a.Length; i++)

            {

                Console.Write(a[i] + " ");

            }

            Console.WriteLine();

        }

    }

}