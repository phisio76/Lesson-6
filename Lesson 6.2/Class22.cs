using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6._2
{
    class Class22
    {
        public static int GetInt(int max) // Проверка ввода значения меньше заданного
        {
            while (true)
                if (!int.TryParse(Console.ReadLine(), out int x) || x > max)
                    Console.Write("Неверный ввод. Необходимо ввести число от 0 до {0}.\nПовторите ввод: ", max);
                else return x;
        }
        public static void Print(double start, double end, double step, double[] values) // метод выводит на экран значения функции и аргумента
        {
            Console.WriteLine("------- X ------- Y -----");
            int index = 0;
            while (start <= end)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} ", start, values[index]);
                start += step;
                index++;
            }
            Console.WriteLine("--------------------------");
        }
    }
}
