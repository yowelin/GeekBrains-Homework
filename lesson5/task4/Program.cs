using System;
using System.IO;
namespace task4
{
    public class RecursiveFileSearch
    {
        static void Main()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\temp");
            WalkDirectoryTree(di);

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        static void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            files = root.GetFiles("*.*");

            foreach (FileInfo fi in files)
            {
                File.AppendAllText("directoryTree.txt", (fi.FullName) +"\n");
            }

            subDirs = root.GetDirectories();

            foreach (DirectoryInfo dirInfo in subDirs)
            {
                File.AppendAllText("directoryTree.txt", (dirInfo.FullName) + "\n");
                WalkDirectoryTree(dirInfo);
            }

        }
    }
}
