using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static bool pal(string s) // создаю функцию на определение палиндрома
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - i - 1]) // проверяю, различны ли соответствующие элементы
                    return false; // возвращаю 0, если соответствующие элементы не одинаковы
            }
            return true; // если все условия соблюдены, строка является палиндромом
        }
        static void Main(string[] args)
        {

            TextReader tr = new StreamReader(@"C:\Users\Айгерим\source\repos\Week2\Task1_2\input.txt");
            string str = "";
            str = tr.ReadLine();
            

            if (pal(str) == true)
                Console.WriteLine("Yes"); // вывожу "Да", если строка - палиндром
            else
                Console.WriteLine("No");
        }
    }
}