using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {

        static void Main(string[] args)
        {
            string fileName = "text.txt"; // задаю название файла
            string sourcePath = @"C:\Users\Айгерим\source\repos\Week2\Task4_2"; // прописываю path
            string targetPath = @"C:\Users\Айгерим\source\repos\Week2\Task4_2\try"; // прописываю path1

            string sourceFile = System.IO.Path.Combine(sourcePath, fileName); // задаю путь, где будет изначальный файл
            string destFile = System.IO.Path.Combine(targetPath, fileName);// задаю путь, куда нужно будет его скопировать


            using (FileStream fs = new FileStream(sourceFile, FileMode.CreateNew, FileAccess.Write)) // создаю документ
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write("rdtfyguhij");
                }
            }

            System.IO.File.Copy(sourceFile, destFile, true); // копирую документ в path1
            System.IO.File.Delete(sourceFile); // удаляю изначальный документ

        }
    }
}
