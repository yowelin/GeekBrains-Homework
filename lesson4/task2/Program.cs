using System;

namespace task2
{
    class Counter
    {
        public int CountSumOfNumbers(string numbers)
        {
            string[] splittedString = numbers.Split(" ");
            int[] splittedNumbers = new int[splittedString.GetLength(0)];
            int sum = 0;
            for (int i = 0; i < splittedString.GetLength(0); i++)
            {
                if(Int32.TryParse(splittedString[i], out splittedNumbers[i]))
                {
                    sum += splittedNumbers[i];
                }
            }
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Counter cntr = new Counter();
            Console.Write("Введите числа через пробел: ");
            Console.Write("Сумма введеных чисел: " + cntr.CountSumOfNumbers(Console.ReadLine()));
        }
    }
}
