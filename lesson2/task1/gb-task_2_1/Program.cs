using System;

namespace gb_task_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double minTemp = 0;
            double maxTemp = 0;
            bool isMinTempNumber = false;
            bool isMaxTempNumber = false;
            beginning:
            do
            {
                isMinTempNumber = false;
                Console.WriteLine("Введите минимальную температуру за сутки:");
                isMinTempNumber = Double.TryParse(Console.ReadLine(), out minTemp);
                if (isMinTempNumber)
                {
                    do
                    {
                        isMaxTempNumber = false;
                        Console.WriteLine("Введите максимальную температуру за сутки:");
                        isMaxTempNumber = Double.TryParse(Console.ReadLine(), out maxTemp);
                        if (isMaxTempNumber)
                        {
                            if (minTemp <= maxTemp)
                            {
                                Console.WriteLine($"Среднесуточная температура: {(minTemp + maxTemp) / 2}");
                            }
                            else
                            {
                                Console.WriteLine("Минимальная температура больше максимальной. Повторите ввод.");
                                goto beginning;
                            }
                        }
                    } while (!isMaxTempNumber);
                }
            } while (!isMinTempNumber);
        }
    }
}
