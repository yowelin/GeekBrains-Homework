using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_task_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            bool flag = false;
            string resultName = "";
            do
            {
                Console.Write("Введите Ваше имя:");
                name = Console.ReadLine();
                //Проверка имени на содержание только русских букв
                foreach (char ch in name)
                {
                    if (ch >= 'А' & ch <= 'я')
                    {
                        flag = true; //если буква русская, то флаг = истина
                    }
                    else
                    {
                        Console.WriteLine("Имя должно состоять только из русских букв.");
                        flag = false; //если символ в слове не русская буква, то флаг = фальш
                        break;
                    }
                }
            }
            while (!flag); //Продолжаем запрашивать у пользователя ввод, до тех пор пока все символы не окажутся русскими буквами.

            //Приведение строки с именем к грамотному виду. Первая буква заглавная, остальные строчные
            for (int i = 0; i < name.Length; i++)
            {
                if (i == 0)
                {
                    resultName += name[i].ToString().ToUpper(); //Делаем первую букву заглавной
                }
                else
                {
                    resultName += name[i].ToString().ToLower(); //Делаем остальные буквы строчными
                }
            }

            Console.WriteLine($"Привет, {resultName}, сегодня {(DateTime.Now):D}");
            Console.Read();
        }
    }
}
