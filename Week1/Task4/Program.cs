using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine(); // считываю строку
            int n = Convert.ToInt32(s); // конвертирую строку в число, чтобы определить размерность
            for (int i = 1; i <= n; i++) // создаю двойной массив, где количество строк увеличивается до нужного размера
            {
                for (int j = 1; j <= i; j++) // а кол-во столбцов увеличивается до тех пор, пока не станет равно кол-ву строк
                {
                    Console.Write("[*]"); // вывожу небходимое количество столбцов данного символа
                }
                Console.WriteLine(); // перехожу на следующую строку
            }

        }
    }
}
