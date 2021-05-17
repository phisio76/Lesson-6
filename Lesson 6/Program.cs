using System; //Павлов Дмитрий. 1. Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double(double, double).
// Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x)..
// 
//
//
//
//
//

namespace Lesson_6
{
    public delegate double Fun(double a, double x);
    class Program
    { 
        static void Main()
        {
            Console.WriteLine("Таблица функции x^3:");
            Class3.Table(new Fun(Class4.MyFunc1), -2, 2, 2);
            Console.WriteLine("Таблица функции a*x^2:");
            Class3.Table(new Fun(Class1.MyFunc), -0.5, -2, 2);

            Console.WriteLine("Таблица функции a*sin(x):");
            Class3.Table(new Fun(Class2.MySin), 3, -2, 2);

            Console.ReadKey();
        }
    }
}
