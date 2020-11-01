using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /*Выполнила Ярмолинская Анастасия
    Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double).
    Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).*/

    class Program
    {

        /// <summary>
        /// Функция
        /// </summary>
        /// <param name="a">Параметр функции</param>
        /// <param name="x">Аргумент функции</param>
        /// <returns></returns>
        public delegate double Fun(double a, double x);

        /// <summary>
        /// Вывод таблицы по значениям
        /// </summary>
        /// <param name="fun">Функция</param>
        /// <param name="minV">Минимальное значение аргумента</param>
        /// <param name="maxV">Максимальное значение аргумента</param>
        /// <param name="a">Параметр функции</param>
        public static void Table(Fun fun, double minV, double maxV, double a)
        {
            Console.WriteLine($"__________");
            for (double x = minV; x <= maxV; x++)
            {
                Console.WriteLine($"{x,3} | {fun(a, x)}");
                Console.WriteLine($"__________");
            }
        }
        
        public static double F(double aF, double xF) { return aF * xF * xF; }
        public static double G(double aG, double xG) { return aG * Math.Sin(xG); }
        static void Main(string[] args)
        {
            Table(F, -2, 2, 2);
            Table(G, -2, 2, 2);
        }
    }
}
