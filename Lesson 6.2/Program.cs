//1. Павлов Дмитрий. модифицировать программу нахождения минимума функции так, чтобы можно было
//передавать функцию в виде делегата.
//а) сделать меню с различными функциями и представить пользователю выбор, для какой
//функции и на каком отрезке находить минимум. использовать массив (или список) делегатов,
//в котором хранятся различные функции.
//б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. Пусть она
// возвращает минимум через параметр (с использованием модификатора out).


using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


namespace Lesson_6._2
{
    public delegate double Fun(double x);

    class Program
    {
        public static void SaveFunc(string fileName, double start, double end, double step, Fun F) //Метод расчрассчитывает значение переданной функции и записывает в файл
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            while (start <= end)
            {
                bw.Write(F(start));
                start += step;
            }
            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName, out double min) // Метод находит минимальное значение
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double[] array = new double[fs.Length / sizeof(double)];
            min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                array[i] = d;
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return array;
        }               
        
        static void GetInterval(out double start, out double end) // Метод получает значения начала отрезка и конца из одной строки
        {
            string[] interval = Console.ReadLine().Split(' ');
            start = double.Parse(interval[0], CultureInfo.InvariantCulture);
            end = double.Parse(interval[1], CultureInfo.InvariantCulture);
        }        

        static void Main(string[] args)
        {
            List<Fun> functions = new List<Fun> { new Fun(Class11.Sum), new Fun(Class11.linear), new Fun(Class11.Squaring), new Fun(Class11.Cubing), new Fun(Class11.Sqrt), new Fun(Class11.Sin) };
            Console.WriteLine("Выберите номер функции.");
            Console.WriteLine("1. f(x)=y+y");
            Console.WriteLine("2. f(x)=k*x+b");
            Console.WriteLine("3. f(x)=y^2");
            Console.WriteLine("4. f(x)=y^3");
            Console.WriteLine("5. f(x)=y^1/2");
            Console.WriteLine("6. f(x)=Sin(y)");
            int Choose = Class22.GetInt(functions.Count);

            Console.WriteLine("Для нахождения минимума введите отрезок в формате х1 х2:");

            double start = 0;
            double end = 0;
            GetInterval(out start, out end);

            Console.WriteLine("Введите размер шага:");
            double step = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            SaveFunc("data.bin", start, end, step, functions[Choose - 1]);
            double min = double.MaxValue;
            Console.WriteLine("Получены следующие значения функции: ");
            Class22.Print(start, end, step, Load("data.bin", out min));
            Console.WriteLine("Минимальное значение функции: {0:0.00}", min);
            Console.ReadKey();
        }
    }
}