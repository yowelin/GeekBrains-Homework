using System;

namespace task3
{
    class Program
    {
        static string strToReverse = "";
        static void Main(string[] args)
        {
            Console.Write("Введите любую строку: ");
            strToReverse = Console.ReadLine();
            Console.Write("Строка наоборот: ");
            for (int i = strToReverse.Length - 1; i >= 0; i--)
            {
                Console.Write(strToReverse[i]);
            }
        }
    }
}
