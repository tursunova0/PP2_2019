using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        private static int[] F(string text)
        {
            List<int> res = new List<int>();
            string[] tx = text.Split(); //  разделяю элементы строки
            for (int i = 0; i < tx.Length; i++)
            {
                res.Add(int.Parse(tx[i])); // присваиваю элементы
            }
            return res.ToArray();
        }

        static public bool Prime(int n) // создаю функцию на определение простого числа
        {
            if ((n == 0) || (n == 1)) // 1 и 0 не являются простыми числами
                return false;
            else
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0) // так же число не является простым, если оно имеет больше двух делителей, т.е. не только 1 и само число
                        return false;
                }
            }
            return true; // если все условия соблюдены, число яляется простым
        }


        static void Main(string[] args)
        {
            int[] inp;
            using (FileStream fs1 = new FileStream(@"C:\Users\Айгерим\source\repos\Week2\Task2_2\input.txt", FileMode.Open, FileAccess.Read)) // открываю необходимую папку, чтобы считать данные
            {
                using (StreamReader sr = new StreamReader(fs1))
                {
                    string text = sr.ReadLine(); // записываю данные в переменную
                    inp = F(text); // перевожу данные в массив
                }
            }

            using (FileStream fs2 = new FileStream(@"C:\Users\Айгерим\source\repos\Week2\Task2_2\output.txt", FileMode.Open, FileAccess.Write)) // открываю необходимую папку, чтобы записать туда данные
            {
                using (StreamWriter sw = new StreamWriter(fs2))
                {
                    for (int i = 0; i < inp.Length; i++) // пробегаюсь по массиву, чтобы проверить, является ли число простым
                    {

                        if (Prime(inp[i])==true)
                        {
                            sw.Write(inp[i] + " "); // если является, записываю его в документ
                        }
                    }
                }
            }
        }
    }
}