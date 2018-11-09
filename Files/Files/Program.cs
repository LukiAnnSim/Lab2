using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files//ИТб-161 Симакова 2 лабораторная
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь");
            string way = Console.ReadLine();
            if (!Directory.Exists(way))
            {
                Console.WriteLine("Такого пути нет");
                Console.ReadKey();
                return;
            }

            Dictionary<String, int> values = new Dictionary<String, int>();//создаем словарь с указанными типами данных
            
            string[] files = Directory.GetFiles(way, "*", SearchOption.TopDirectoryOnly);
            if (files.Count() == 0)
            {
                Console.WriteLine("Эта папка пуста");
                Console.ReadKey();
                return;
            }
            for (int i = 0; i < files.Length; i++)
            {

                int lastPoint = files[i].LastIndexOf(".") + 1;
                String exp = files[i].Substring(lastPoint);
                if (values.ContainsKey(exp))
                {
                    values[exp]++;
                }
                else
                {
                    values.Add(exp, 1);
                }

            }
            
            var res = values.OrderByDescending(v => v.Value);
            
            int y = 0;
            foreach (KeyValuePair<String, int> kvp in res)
            {
                if (y == Math.Min(res.Count(), 5))
                    break;
                y++;
                Console.WriteLine("Расширение: " + kvp.Key + ", Количество: " + kvp.Value);
                
            }
            Console.ReadKey();
        }
    }
}
