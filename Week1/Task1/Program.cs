using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static public bool Prime(int n)
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
            int p = int.Parse(Console.ReadLine());  // считываю количество элементов
            string s = Console.ReadLine(); // считываю строку со значениями элементов
            string[] ss = s.Split(); // разделяю элементы строки
            int[] a = new int[p]; // создаю пустой массив чисел
            for (int i = 0; i < p; i++)
            {
                a[i] = int.Parse(ss[i]); // присваиваю элементу массива соответствующий элемент строки
            }
            int cnt = 0; // создаю новое значение
            for (int i = 0; i < p; i++)
            {
                if (Prime(a[i]) == true)
                    cnt++; // определяю количество нужных элементов (простых чисел)
            }
            Console.WriteLine(cnt); // вывожу количество простых чисел
            for (int i = 0; i < p; i++)
            {
                if (Prime(a[i]) == true)
                    Console.Write(a[i] + " "); // вывожу сами числа
            }
        }
    }
}

