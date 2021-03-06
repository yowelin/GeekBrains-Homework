using System;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите произвольные данные: ");
            File.WriteAllText("task5_1.txt", Console.ReadLine());
        }
    }
}
