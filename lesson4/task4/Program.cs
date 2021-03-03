using System;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            beginning:
            UInt64 fibonacciNumber = 0;
            Console.WriteLine("Сколько чисел Фибоначчи вывести на экран?");
            if (UInt64.TryParse(Console.ReadLine(), out fibonacciNumber) & fibonacciNumber > 0)
            {
                for (UInt64 i = 0; i < fibonacciNumber; i++)
                {
                    Console.Write(GetFibonacci(i) + ( i == fibonacciNumber - 1 ? ", ...": ", "));
                }
            }
            else
            {
                Console.WriteLine("Введите натуральное число.");
                goto beginning; // лень писать цикл
            }
        }
        static UInt64 GetFibonacci(UInt64 number)
        {
            if (number == 1 | number == 0) // терминальное условие
            {
                return number;
            }
            return GetFibonacci(number - 1) + GetFibonacci(number - 2); // рекурсивный вызов
        }
    }
}
