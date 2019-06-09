using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tassk6
{
    class Program
    {
        public static void Color(string txt)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(txt);
            Console.ResetColor();
        }
        public static void Error(string txt)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(txt);
            Console.ResetColor();
        }

        public static void Repeat(List<int> lis, int M, int x, ref int m)
        {
            if (m < M)
            {
                m = lis[x - 1] * lis[x - 2] + lis[x - 3];
                lis.Add(m);
                x++;
                Repeat(lis, M, x, ref m);
            }            
        }

        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            bool ok = true;
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    Color($"Введите {i + 1} число:");
                    try
                    {
                        int a = Int32.Parse(Console.ReadLine());
                        list.Add(a);
                        ok = true;
                    }
                    catch
                    {
                        ok = false;
                        Error("Ошибка, введите целое число");
                    }
                } while (!ok);
            }

            int M = 0;
            do
            {
                Color("Введите максимум:");
                try
                {
                    M = Int32.Parse(Console.ReadLine());
                    ok = true;
                }
                catch
                {
                    ok = false;
                    Error("Ошибка, введите целое число");
                }
            } while (!ok);
            int m = 0;
            Repeat(list, M, 3, ref m);

            foreach (int v in list)
            {
                Console.Write(v + " ");
            }

            if (m == M) Color("\nПоследний элемент последовательности равен введенному максимуму");
            else Color("\nПоследний элемент последовательности не равен введенному максимуму");
            Console.ReadKey();
        }
    }
}
