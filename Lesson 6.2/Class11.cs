using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6._2
{
    class Class11
    {
        public static double Sum(double x) // простое сложение
        {
            return x + x;
        }
        public static double linear(double x) // линейная функция
        {
            return 2 * x + 3;
        }
        public static double Squaring(double x) // возведение в квадрат
        {
            return x * x;
        }
        public static double Cubing(double x) // возведение в куб
        {
            return x * x * x;
        }
        public static double Sqrt(double x) // извлечение квадратного корня
        {
            return Math.Sqrt(x);
        }
        public static double Sin(double x) // возвращает синус
        {
            return Math.Sin(x);
        }
    }
}
