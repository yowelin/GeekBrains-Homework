using System;

namespace task3
{
    enum Season
    {
        Winter = 1,
        Spring = 2,
        Summer = 3,
        Autumn = 4
    }
    class SeasonGetter
    {
        public Season GetSeason(int month)
        {
            if (month == 12 | month == 1 | month == 2)
            {
                return Season.Winter;
            }
            if (month == 3 | month == 4 | month == 5)
            {
                return Season.Spring;
            }
            if (month == 6 | month == 7 | month == 8)
            {
                return Season.Summer;
            }
            if (month == 9 | month == 10 | month == 11)
            {
                return Season.Autumn;
            }
            return 0;
        }
        public string ConvertSeasonToString(Season season)
        {
            switch (season)
            {
                case Season.Winter:
                    return "Зима";
                case Season.Spring:
                    return "Весна";
                case Season.Summer:
                    return "Лето";
                case Season.Autumn:
                    return "Осень";
            }
            return "Ошибка: введите число от 1 до 12";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SeasonGetter sg = new SeasonGetter();
            int seasonNum = 0;
            Console.WriteLine("Введите число месяца: ");
            if (Int32.TryParse(Console.ReadLine(), out seasonNum))
            {
                Console.WriteLine(sg.ConvertSeasonToString(sg.GetSeason(seasonNum)));
            }

        }
    }
}
