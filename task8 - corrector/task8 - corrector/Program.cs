using System;

namespace task8___corrector
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
            return y + 3 * Math.Pow(x, 2) + 2 *  v * x - Math.Pow(x, 3) - v * Math.Pow(x, 2);
        }
        static void Main(string[] args)
        {
            // Границы отрезка
            const double a = 0;
            const double b = 1;

            //номер варианта
            const double v = 7;

            // Начальное условие
            const double y0 = 0;

            // Число точек
            const int n = 10;

            // Шаг
            const double h = (b - a) / n;

            // Значения аргументов
            double[] x = new double[n + 1];

            // Предсказываемое решение 
            double[] y_predict = new double[n + 1];

            // Корректируемое решение
            double[] y = new double[n + 1];

            x[0] = a;
            y[0] = y0;

            for (int i = 1; i <= n; i++)
            {
                x[i] = x[i - 1] + h;
                y_predict[i] = y[i - 1] + h * calculate_f(x[i - 1], y[i - 1], v);
                y[i] = y[i - 1] + h / 2 * (calculate_f(x[i - 1], y[i - 1], v) + calculate_f(x[i], y_predict[i], v));
            }
            Console.WriteLine("x[]  Yточн  y[]");
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("{0}  {1}  {2}", x[i], calculate_y(x[i], v), y[i]);
            }
            Console.ReadLine();
        }
    }
}
