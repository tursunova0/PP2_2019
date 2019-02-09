using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void PrintInfo(FileSystemInfo fsi, int n) // создаю функцию
        {
            string s = new string(' ', n);
            Console.WriteLine(s + fsi.Name);

            if (fsi.GetType() == typeof(DirectoryInfo)) // если файл является папкой
            {
                FileSystemInfo[] arr = ((DirectoryInfo)fsi).GetFileSystemInfos(); // иду дальше
                for (int i = 0; i < arr.Length; ++i)
                {
                    PrintInfo(arr[i], n + 3); // вывожу и делаю отступ
                }
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Айгерим\source\repos\Week2"); // указываю необходимую папку
            PrintInfo(dir, 0); // вызываю функцию 
        }
    }
}