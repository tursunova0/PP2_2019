using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{    
        class Layer
        {
            private int selectedItem;
            public int SelectedItem
            {
                get
                {
                    return selectedItem;
                }

                set
                {
                    if (value >= Content.Count)
                    {
                        selectedItem = 0;
                    }
                    else if (value < 0)
                    {
                        selectedItem = Content.Count - 1;
                    }
                    else
                    {
                        selectedItem = value;
                    }
                }
            }



            public List<FileSystemInfo> Content
            {
                get;
                set;
            }

            public void DeleteSelectedItem()
            {
                FileSystemInfo fileSystemInfo = Content[selectedItem];

                if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                {
                    Directory.Delete(fileSystemInfo.FullName, true);
                }

                else
                {
                    File.Delete(fileSystemInfo.FullName);
                }

                Content.RemoveAt(selectedItem);
                selectedItem--;
            }

            public void Draw()
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();

                for (int i = 0; i < Content.Count; ++i)
                {
                    if (i == SelectedItem)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(Content[i].Name);
                }
            }
        }

    enum FARMode
    {
        DIR,
        FILE
    }

    class Program
    {
        static void Main(string[] args)
        {
            FARMode mode = FARMode.DIR; // текущее состояние
            DirectoryInfo root = new DirectoryInfo(@"C:\Users\Айгерим\Desktop\Новая папка");
            Stack<Layer> history = new Stack<Layer>(); // создаю stack
            history.Push(   // закидываю нужную папку
                    new Layer
                    {
                        Content = root.GetFileSystemInfos().ToList(),
                        SelectedItem = 0
                    }
                );

            while (true)
            {
                if (mode == FARMode.DIR)
                {
                    history.Peek().Draw(); // обновляю каждый раз
                }

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();  // нажатие клавиш и необходимые действия
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Delete: // на клавише delete удалить
                        history.Peek().DeleteSelectedItem();
                        break;

                    case ConsoleKey.UpArrow: // листать вверх
                        history.Peek().SelectedItem--;
                        break;

                    case ConsoleKey.DownArrow: // листать вниз
                        history.Peek().SelectedItem++;
                        break;

                    case ConsoleKey.Backspace: // вернуться назад
                        if (mode == FARMode.DIR)
                        {
                            history.Pop();
                        }
                        else
                        {
                            mode = FARMode.DIR;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        }
                        break;

                    case ConsoleKey.Enter:  // открыть папку или файл

                        int x = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo as DirectoryInfo;
                            history.Push(
                               new Layer
                               {
                                   Content = directoryInfo.GetFileSystemInfos().ToList(),
                                   SelectedItem = 0
                               });
                        }

                        else
                        {
                            mode = FARMode.FILE;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Black;
                            using (StreamReader sr = new StreamReader(fileSystemInfo.FullName))
                            {
                                Console.WriteLine(sr.ReadToEnd());
                            }
                        }
                        break;
                }
            }
        }
    }
}