using System;

namespace task1
{
    class FIO 
    {
        public string GetFullName(string firstName, string lastName, string patronymic)
        {
            return firstName + " " + lastName + " " + patronymic;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FIO fio = new FIO();
            Console.WriteLine(fio.GetFullName("Семикин", "Иван", "Николаевич"));
            Console.WriteLine(fio.GetFullName("Трофимова", "Татьяна", "Кимовна"));
            Console.WriteLine(fio.GetFullName("Новикова", "Ольга", "Викторовна"));
        }
    }
}
