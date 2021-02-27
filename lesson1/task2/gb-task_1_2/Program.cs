using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_task_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool IsPasswordValid = false;
            do
            {
                Console.Write("Введите пароль:");
                string password = Console.ReadLine();
                IsPasswordValid = checkPasswordForValidity(password);
                Console.WriteLine(IsPasswordValid ? "Пароль верен." : "Пароль неверен.");
            } while (!IsPasswordValid);
            
        }
        static bool checkPasswordForValidity(string pass)
        {
            int[] eachSymbol = { };
            bool flag1 = false;
            bool resultFlag = false;
            if (pass.Length >= 4 & pass.Length <= 6)
            {
                eachSymbol = new int[pass.Length];
                for (int i = 0; i < pass.Length; i++)
                {
                    if (Int32.TryParse(pass[i].ToString(), out eachSymbol[i]))
                    {
                        flag1 = true;
                    }
                    else
                    {
                        flag1 = false;
                        Console.WriteLine("пароль должен состоять только из цифр.");
                        break;
                    }
                }
                if (flag1)
                {
                    for (int i = 0; i < eachSymbol.Length - 1; i++)
                    {
                        if (eachSymbol[i] == eachSymbol[i + 1])
                        {
                            resultFlag = false;
                            Console.WriteLine("Не должно быть 2 одинаковых символа подряд.");
                            break;
                        }
                        else
                        {
                            resultFlag = true;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Введите от 4 до 6 цифр.");
            }
            return resultFlag;
        }
    }
}
