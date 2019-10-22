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
        static double determinant = 1;
        static void Main(string[] args)
        {
            FileStream file1 = new FileStream("./input.txt", FileMode.Open);
            string[] mas;
            double[][] a; // массив коэффициентов
            double[][] a1; //второй массив ответов
            double[] b; // массив ответов
            using (var file = new StreamReader(file1))
            {
                n = int.Parse(file.ReadLine());
                a = new double[n][];
                a1 = new double[n][];
                for (int i = 0; i < n; i++)
                {
                    mas = (file.ReadLine()).Split(' ');
                    a[i] = new double[n];
                    a1[i] = new double[n];
                    for (int j = 0; j < n; j++)
                    {
                        a[i][j] = double.Parse(mas[j]); //заполняем массив коэффициентов
                        a1[i][j] = double.Parse(mas[j]);
                    }
                }
                mas = (file.ReadLine()).Split(' ');
                b = new double[n];
                for (int i = 0; i < n; i++)
                {
                    b[i] = int.Parse(mas[i]); // заполняем значениями массив ответов
                }
            }
            PrintTwo(a);          
            PrintOne(b);

            Console.WriteLine("________");
            //PrintTwo(a1);

            double[] x = MethodGauss(a, b, 1);
            Console.WriteLine();
            Console.WriteLine("x:");
            PrintOne(x);
            //Console.WriteLine();
            //Console.WriteLine("__________");

            Console.WriteLine();
            Sub(a1, x, n);
            Console.WriteLine();
            ReverseMatrix(a1);




        }
        public static double[] MethodGauss(double[][] aFirst, double[] b, int f)
        {
            double[][] a = new double[n][];

            for (int i = 0; i < n; i++)
            {
                a[i] = new double[n];
                a[i] = aFirst[i];
            }

            int y = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i][i] == 0)
                {
                    y++;
                    int indexRows = FindMainInRows(a, i);
                    if (indexRows == -1)
                    {
                        break;
                    }
                    SwapRows(a, i, indexRows);
                    //Swap(b[i], b[indexRows])
                    double tmp = b[i];
                    b[i] = b[indexRows];
                    b[indexRows] = tmp;
                }
                double mainElement = a[i][i];
                determinant *= mainElement;
                for (int j = 0; j < n; j++)
                {
                    a[i][j] /= mainElement;
                }
                b[i] /= mainElement;
                SubstractRaws(a, i, b);
            }
            double[] x = new double[n];
            if (f == 1)

            {

                determinant *= Math.Pow(-1, y);

                Console.WriteLine("Определитель = " + (determinant));

            }

            
            //Обратный ход
            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = b[i];
                for (int j = i + 1; j < n; j++)
                {
                    x[i] -= x[j] * a[i][j];
                }
            }
            for (int i = 0; i < n; ++i)
            {
                double[] c = aFirst[i];
                //Console.WriteLine("________");
                //PrintOne(c);
                //Console.WriteLine("________");
                double res = 0;
                for (int j = 0; j < n; ++j)
                {
                    res += c[j] * x[j];
                }

                //Console.WriteLine(res);
            }
            return x;
        }
        public static void PrintTwo(double[][] a)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void PrintOne(double[] a)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
        public static int FindMainInRows(double[][] a, int index)
        {
            if (index + 1 < n)
            {
                int indexMax = index + 1;
                double maxElementAbs = Math.Abs(a[indexMax][index]);
                for (int j = index + 1; j < n; j++)
                {
                    if (Math.Abs(a[j][index]) > maxElementAbs)
                    {
                        maxElementAbs = Math.Abs(a[j][index]);
                        indexMax = j;
                    }
                }
                return indexMax;
            }
            else
                return -1;
        }
        public static void SwapRows(double[][] a, int i, int j)
        {
            double[] temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
        public static void SubstractRaws(double[][] a, int i, double[] b)
        {
            for (int l = i + 1; l < n; l++)
            {
                double d = a[l][i];
                for (int j = i; j < n; j++)
                {
                    a[l][j] = a[l][j] - a[i][j] * d;
                }
                b[l] = b[l] - b[i] * d;
            }
        }
        public static void Sub(double[][] A, double[] B, int n)
        {
            Console.WriteLine("Проверка:");
            for (int i = 0; i < n; ++i)
            {
                double[] c = A[i];
                //Console.WriteLine("________");
                //PrintOne(c);
                //Console.WriteLine("________");
                double res = 0;
                for (int j = 0; j < n; ++j)
                {
                    res += c[j] * B[j];
                }

                Console.WriteLine(res);
            }
        }

        public static void ReverseMatrix(double[][] a)

        {

            double[][] aReverse = new double[n][];

            double[] b = new double[n];

            double[][] e = new double[n][];

            for (int i = 0; i < n; i++)

            {

                b[i] = 0;

                aReverse[i] = new double[n];

                e[i] = new double[n];

            }

            double[] helper = new double[n];

            for (int i = 0; i < n; i++) {

                double[][] a2 = new double[n][];
                for (int k1 = 0; k1 < n; ++k1)
                {

                    a2[k1] = new double[n];
                    for (int k2 = 0; k2 < n; ++k2)
                    {
                        a2[k1][k2] = a[k1][k2];
                    }
                }

                b[i] = 1;

                for (int j = 0; j < n; j++)

                {

                    aReverse[j][i] = helper[j];
                    b[j] = 0;

                }
                
            }

            PrintTwo(aReverse);

            Console.WriteLine("Проверка обратной матрицы ");

            double sum;

            int k = 0;

            for (int i = 0; i < n; i++)

            {

                sum = 0;

                for (int j = 0; j < n; j++)

                {

                    sum += a[i][j] * aReverse[j][i];

                }

                e[i][k] = sum;

                if (k < 8)

                    k++;

                else

                    k = 0;

            }

            PrintTwo(e);

        }

    }

}