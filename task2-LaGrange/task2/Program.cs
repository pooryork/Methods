using System;
using System.Text;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] mas_x = new double[] { 1, 2, 3, 4 };
            double[] mas_y = new double[] { 7, 28, 63, 112 };

            StringBuilder first = new StringBuilder(), second = new StringBuilder();

            int length = mas_x.Length - 1;
            for (int i = 0; i < length; i++)
            {
                first.Append("x = " + mas_x[i] + ", ");
                second.Append("y = " + mas_y[i] + ", L(x) = ");
                double x = (mas_x[i] + mas_x[i + 1]) / 2;  //( x(i) + x(i+1) )/2
                double la_Grange = 0;
                for (int j = 0; j <= length; j++)
                {
                    double l = 1;

                    for (int k = 0; k <= length; k++)
                    {
                        if (j != k)
                        {
                            l *= (x - mas_x[k])/(mas_x[j] - mas_x[k]);
                        }
                    }
                    l *= mas_y[j];
                    la_Grange += l;

                }
                first.Append("sub_x = " + x + " | ");
                second.Append(System.Math.Round(la_Grange, 4) + " | ");

            }
            /*first.Append(mas_x[2] + "  |");
            second.Append(mas_y[2] + "  |");*/
            Console.WriteLine(first);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine(second);
        }
    }
}