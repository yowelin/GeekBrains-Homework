using System;

namespace task5
{
    class Program
    {
        string[] Months = new string[12]
{
            "Январь",
            "Феварль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"
};
        static void Main(string[] args)
        {
            double minTemp = 0;
            double maxTemp = 0;
            double avgTemp = 0;
            bool isMinTempNumber = false;
            bool isMaxTempNumber = false;

            Program prg = new Program(); //приходится создавать объект класса Program
            ushort monthNumber = 0;
            bool isMonthNumerUint = false;
            string monthName = "";
            bool isMonthNumberRight = false;

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
                                avgTemp = (minTemp + maxTemp) / 2;
                                Console.WriteLine($"Среднесуточная температура: {avgTemp}");
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


            do
            {
                Console.WriteLine("Введите порядковый номер текущего месяца:");
                isMonthNumerUint = UInt16.TryParse(Console.ReadLine(), out monthNumber);
                if (isMonthNumerUint & monthNumber >= 1 & monthNumber <= 12)
                {
                    monthName = prg.Months[monthNumber - 1];
                    isMonthNumberRight = true;
                }
                else
                {
                    isMonthNumberRight = false;
                }
            } while (!isMonthNumerUint | !isMonthNumberRight);
            Console.WriteLine(monthName);

            if ((monthName == "Декабрь" | monthName == "Январь" | monthName == "Февраль") & avgTemp > 0)
            {
                Console.WriteLine("Дождливая зима!");
            }
        }
    }
}
