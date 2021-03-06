using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort numberToCheck = 0;
            string strToCheck = "";
            bool isEnteredNumber = false;
            beginning:
            Console.WriteLine("Введите число:");
            strToCheck = Console.ReadLine();
            isEnteredNumber = UInt16.TryParse(strToCheck, out numberToCheck);
            if (isEnteredNumber & numberToCheck != 0)
            {
                if (numberToCheck % 2 == 0)
                {
                    Console.WriteLine("Число чётное.");
                }
                else
                {
                    Console.WriteLine("Число нечётное.");
                }
            }
            else
            {
                goto beginning;
            }

        }
    }
}
