using System;
using System.IO;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bytesString = Console.ReadLine().Split(" ");
            byte[] b = new byte[bytesString.Length];
            bool flag = false;
            for (int i = 0; i < bytesString.Length; i++)
            {
                
                if (byte.TryParse(bytesString[i], out b[i]))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                File.WriteAllBytes("bytes.bin", b);
            }
            else
            {
                Console.WriteLine("Введите числа от 0 до 255");
            }
        }
    }
}
