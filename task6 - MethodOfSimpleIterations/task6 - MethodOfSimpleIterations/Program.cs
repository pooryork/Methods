using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Math4
{
    class Program
    {
        static int n;
        static double eps = 0.01;
        static void Main(string[] args)
        {
            FileStream file1 = new FileStream("input.txt", FileMode.Open); //создаем файловый поток           
            string[] mas;
            double[][] a;
            double[] b;

            //Считываем массив из файла
            using (var file = new StreamReader(file1))
            {
                n = int.Parse(file.ReadLine());
                a = new double[n][];
                for (int i = 0; i < n; i++)
                {
                    mas = (file.ReadLine()).Split(' ');
                    a[i] = new double[n];
                    for (int j = 0; j < n; j++)
                    {
                        a[i][j] = double.Parse(mas[j]);
                    }
                }
                mas = (file.ReadLine()).Split(' ');
                b = new double[n];
                for (int i = 0; i < n; i++)
                {
                    b[i] = double.Parse(mas[i]);
                }
            }
            Console.WriteLine("a =");
            PrintTwo(a);
            Console.WriteLine("_________________");
            Console.WriteLine("b =");
            PrintOne(b);
            Console.WriteLine("_________________");

            double[][] alifa = new double[n][];
            double[] beta = new double[n];

            NewMatrix(a, b, alifa, beta);
            Console.WriteLine("Alpha =");
            PrintTwo(alifa);
            Console.WriteLine("_________________");
            Console.WriteLine("Beta = ");
            PrintOne(beta);
            Console.WriteLine("_________________");

            //  MethodSimpleInteration(a, b);

            MethodSimpleInteration(alifa, beta);

        }
        public static void NewMatrix(double[][] a, double[] b, double[][] alifa, double[] beta)
        {
            for (int i = 0; i < n; i++)
            {
                alifa[i] = new double[n];
                for (int j = 0; j < n; j++)
                {
                    alifa[i][j] = -a[i][j] / a[i][i];
                                    }
                beta[i] = b[i] / a[i][i];
                alifa[i][i] = 0;
            }
        }
        public static void MethodSimpleInteration(double[][] a, double[] b)
        {
            double[] x_k = new double[n];
            double[] x_k1 = new double[n];

            for (int k = 0; ; k++)
            {
                double[] res = new double[n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        res[i] += a[i][j] * x_k[j];
                        //Console.WriteLine("i={0}, j={1}, res[i]={2}, a[i][j]={3}, x_k[j]={4}", i, j, res[i], a[i][j], x_k[j]);
                        
                    }
                    //Console.WriteLine("________");
                }
                for (int i = 0; i < n; i++)
                {
                    x_k1[i] = res[i] + b[i];
                    //Console.WriteLine("x_k1[i]={0}, res[i]={1}, b[i]={2}", x_k1[i], res[i], b[i]);
                    
                }
                //Console.WriteLine("________");
                double[] w = new double[n];
                for (int i = 0; i < n; i++)
                {
                    w[i] = x_k1[i] - x_k[i];
                    //Console.WriteLine("w[i]={0}, x_k1[i]={1}, x_k[i]={2}", w[i], x_k1[i], x_k[i]);
                    
                }
                //Console.WriteLine("________");
                double norma = Max(w);
                if (norma < eps)
                {
                    break;
                }
                Console.WriteLine("norma = " + norma);
                //Console.WriteLine("k = " + k);
                Console.WriteLine("k + 1  = " + (k + 1));
                for (int j = 0; j < n; j++)
                {
                    Console.Write(System.Math.Round(x_k1[j], 10) + " ");
                }
                Console.WriteLine();
                
                for (int i = 0; i < n; i++)
                {
                    x_k[i] = x_k1[i];
                }
            }
        }
        public static void MethodSimpleInteration2(double[][] alifa, double[] beta)
        {
            double[] x_k = new double[n];
            for (int i = 0; i < n; i++)
            {
                x_k[i] = 0;
            }
            double[] x_k1 = new double[n];
            for (int k = 0; ; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            sum += alifa[i][j] * x_k[j];
                        }
                    }
                    x_k1[i] = beta[i] + sum;
                }
                double[] w = new double[n];
                for (int i = 0; i < n; i++)
                {
                    w[i] = x_k1[i] - x_k[i];
                }
                double norma = Max(w);
                Console.WriteLine("norma = " + norma);
                Console.WriteLine("k = " + k);
                Console.WriteLine("k + 1  = " + (k + 1));
                for (int j = 0; j < n; j++)
                {
                    Console.Write(System.Math.Round(x_k1[j], 6) + " ");
                }
                Console.WriteLine();
                if (norma < eps)
                {
                    break;
                }
                for (int i = 0; i < n; i++)
                {
                    x_k[i] = x_k1[i];
                }
            }
        }
        public static double Max(double[] x)
        {
            double norma = 0;
            for (int i = 0; i < n; i++)
            {
                norma += x[i] * x[i];
            }
            return Math.Sqrt(norma);
        }
        public static void PrintTwo(double[][] a)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(System.Math.Round(a[i][j], 2) + " ");
                }
                Console.WriteLine();
            }
        }
        public static void PrintOne(double[] a)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(System.Math.Round(a[i], 2) + " ");
            }
        }
    }
}
