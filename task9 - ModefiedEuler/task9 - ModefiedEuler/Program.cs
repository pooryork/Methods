using System;

namespace task9___ModefiedEuler
{
    class Program
    {
        // Следующая функция возвращает значение
        // точного решения задачи в точке x;
        public static double calculate_y(double x, double v)
        {
            return Math.Pow(x, 3) + v * Math.Pow(x, 2);
        }

        // Следующая функция возвращает значение
        // правой части исходной задачи по
        // заданным аргументам x и y
        public static double calculate_f(double x, double y, double v)
        {
            return y + 3 * Math.Pow(x, 2) + 2 * v * x - Math.Pow(x, 3) - v * Math.Pow(x, 2);
        }

        static void Main(string[] args)
        {
            // Границы отрезка
            const double a = 0;
            const double b = 1;

            // Начальное условие
            const double y0 = 0;

            //номер варианта
            const double v = 7;

            // Число точек
            const int n = 10;

            // Шаг
            const double h = (b - a) / n;

            // Значения аргументов
            double[] x = new double[n + 1];

            // Приближенные значения решения
            double[] y = new double[n + 1];

            x[0] = a;
            y[0] = y0;

            for (int i = 1; i <= n; i++)
            {
                x[i] = x[i - 1] + h;
                y[i] = y[i - 1] + h * calculate_f(x[i - 1] + h / 2, y[i - 1] + h / 2 * calculate_f(x[i - 1], y[i - 1], v), v);
            }
            Console.WriteLine("x[]  Yточн  y[]  Погрешность");
            for (int i = 0; i <= n; i++)
            {
                double error = Math.Abs(y[i] - calculate_y(x[i], v));
                Console.WriteLine("{0}  {1}  {2}  {3}", x[i], calculate_y(x[i], v), y[i], error);
            }
            Console.ReadLine();
        }
    }
}
