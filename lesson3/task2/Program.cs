using System;

namespace task2
{
    class Program
    {
        static string[,] telBook = new string[0, 2];
        static void Main(string[] args)
        {
            do {
                telBook = AddContact();
                showContacts();
            } while (Console.ReadLine().ToString().ToLower() != "exit");
        }

        static string[,] AddContact()
        {
            string contactName = "";
            string contactTelOrEmail = "";
            Console.Write("Введите имя контакта: ");
            contactName = Console.ReadLine();
            Console.Write("Введите телефон или e-mail контакта: ");
            contactTelOrEmail = Console.ReadLine();
            string[,] newTelBook = new string[telBook.GetLength(0) + 1, 2];
            for (int i = 0; i < telBook.GetLength(0); i++)
            {
                newTelBook[i, 0] = telBook[i, 0];
                newTelBook[i, 1] = telBook[i, 1];
            }
            newTelBook[telBook.GetLength(0), 0] = contactName;
            newTelBook[telBook.GetLength(0), 1] = contactTelOrEmail;

            return newTelBook;
        }

        static void showContacts()
        {
            for (int i = 0; i < telBook.GetLength(0); i++)
            {
                Console.WriteLine("Contact {0}: {1,-25} {2,15}", i+1, telBook[i, 0], telBook[i, 1]);
            }
        }
    }
}
