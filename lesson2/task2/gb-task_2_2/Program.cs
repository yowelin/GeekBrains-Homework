using System;

namespace gb_task_2_2
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
            Program prg = new Program(); //приходится создавать объект класса Program
            ushort monthNumber = 0;
            bool isMonthNumerUint = false;
            string monthName = "";
            bool isMonthNumberRight = false;
            do
            {
                Console.WriteLine("Введите порядковый номер текущего месяца:");
                isMonthNumerUint = UInt16.TryParse(Console.ReadLine(), out monthNumber);
                if (isMonthNumerUint & monthNumber >= 1 & monthNumber <= 12)
                {
                    monthName = prg.Months[monthNumber-1];
                    isMonthNumberRight = true;
                }
                else
                {
                    isMonthNumberRight = false;
                }
            } while (!isMonthNumerUint | !isMonthNumberRight);
            Console.WriteLine(monthName);
        }
    }
}
