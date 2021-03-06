using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace task5
{
    class ToDo
    {
        public string Title { get; set; }
        public bool isDone { get; set; }
        public ToDo()
        {

        }
        public ToDo(string title, bool isdone)
        {
            Title = title;
            isDone = isdone;
        }
        //Эти методы не используются, вместо них используются свойства
        /*public void AddTask(string title)
        {
            Title = title;
            isDone = false;
        }
        public void SetAsDone()
        {
            isDone = true;
        }*/
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Создаем коллекцию из заданий
            List<ToDo> toDoList = new List<ToDo>();
            //Если файл с заданимяи существует, то загружаем его в коллекцию
            if (File.Exists("todolist.json"))
            {
                string json = File.ReadAllText("todolist.json");
                toDoList = JsonSerializer.Deserialize<List<ToDo>>(json);
            }
            //Проверяем наличие праметров командной строки, если их нет, то просто выводим список задач
            if (args.Length != 0)
            {
                //Если первый аргумент -add, то добавляем новую задачу с Title из второго аргумента и сохраняем все в файл
                if (args[0] == "-add")
                {
                    if (args.Length == 2)
                    {
                        toDoList.Add(new ToDo(args[1], false));
                        string json = JsonSerializer.Serialize(toDoList);
                        File.WriteAllText("todolist.json", json);
                    }
                    else
                    {
                        Console.WriteLine("Введите название задачи.");
                    }

                }

                //Если первый аргумент -done, то помечаем задачу с номером из второго аргумента как true и сохраняем все в файл
                if (args[0] == "-done")
                {
                    int taskToSetAsDone = 0;
                    if (args.Length == 2 && Int32.TryParse(args[1], out taskToSetAsDone) && (taskToSetAsDone >= 1 & taskToSetAsDone <= toDoList.Count))
                    {
                        toDoList[taskToSetAsDone - 1].isDone = true;
                        string json = JsonSerializer.Serialize(toDoList);
                        File.WriteAllText("todolist.json", json);
                    }
                    else
                    {
                        Console.WriteLine("Введите номер задания");
                    }
                }

                ShowAllTasks();
            }
            else
            {
                ShowAllTasks();
            }
            //Отдельный метод для отображения всех задач
            void ShowAllTasks()
            {
                int i = 0;
                foreach (ToDo task in toDoList)
                {
                    i++;
                    Console.WriteLine((task.isDone ? "[+] " : "[-] ") + i + " " + task.Title);
                }
            }
        }
    }
}
