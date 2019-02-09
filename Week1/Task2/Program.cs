using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student // создаю класс
    {
        private string name;  // создаю его переменные
        private string id;
        private int year;

        public Student(string name, string id) // создаю конструктор
        {
            this.name = name; // (квалификация элементов)
            this.id = id;
            this.year = 1;
        }

        public void PrintInfo() // вывожу информацию о студенте
        {
            Console.WriteLine(name + " " + id + " " + year);
        }

        public void Incr()  // увеличаю год обучения
        {
            year++;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Dias", "18BD"); // создаю нового студента
            s.PrintInfo(); // вывожу начальные данные
            s.Incr(); // увеличиваю год обучения
            s.PrintInfo(); // вывожу конечные данные
        }
    }
}
