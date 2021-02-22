using System;

namespace task6
{
    class Program
    {
        [Flags]
        enum weekDays
        {
            Monday = 0b_0000001,
            Tuesday = 0b_0000010,
            Wendesday = 0b_0000100,
            Thursday = 0b_0001000,
            Friday = 0b_0010000,
            Saturday = 0b_0100000,
            Sunday = 0b_1000000
        }
        static void Main(string[] args)
        {
            int[] offices = new int[5] { 0b_0011111, 0b_1110011, 0b_0001100, 0b_0110011, 0b_1001100 };
            for (int i = 0; i < offices.Length; i++)
            {
                Console.WriteLine($"Office #{i + 1} works on: {(weekDays)offices[i]}");
            }
        }
    }
}
