using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public static int[] Dublicate (string [] arr)
        {
            int[] doublearr = new int[2 * arr.Length];

            for (int i = 0; i < arr.Length; ++i)
            {
                int x = int.Parse(arr[i]);
                doublearr[2 * i] = x;
                doublearr[2 * i + 1] = x;
            }

            return doublearr;
        }
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            int n = int.Parse(s1);
            string[] givenarr = s2.Split();
            int[] ans = Dublicate(givenarr);
            for (int i = 0; i < 2 * n; ++i)
            {
                Console.Write(ans[i] + " ");
            }
        }
    }
}


