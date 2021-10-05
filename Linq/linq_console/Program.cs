using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\ttask1");//task 1
            int i = 1;
            string str = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
            IEnumerable<string> list_str =
                from s in str.Split(',')
                select (Convert.ToString(i++) + "." + s);
            foreach (string s in list_str)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\n\ttask2");//task2
            int found = 0;
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            Dictionary<string, DateTime> diction = new Dictionary<string, DateTime>();
            string str2 = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";
            string[] players = str2.Split(';');
            foreach (string s2 in players)
            {
                found = s2.IndexOf(',');
                string key = s2.Substring(0, found);
                DateTime time = Convert.ToDateTime(s2.Substring(found + 2));
                diction.Add(key, time);
            }
            IEnumerable<string> temp =
                from n in diction
                orderby n.Value
                select n.Key + ", " + DateTime.Parse(Convert.ToString(n.Value)).ToShortDateString() + "\tAge = " + (now - int.Parse(n.Value.ToString("yyyyMMdd"))) / 10000;

            foreach (string s2 in temp)
            {
                Console.WriteLine(s2);
            }

            Console.WriteLine("\n\ttask3");//task3
            string str_task3 = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            string[] all_task3 = str_task3.Split(',');

            string all_time = "00.00"; //вводим переменную all_time и задаем стартовый отсчет.
            DateTime t3 = DateTime.ParseExact(all_time.ToString(), "mm.ss", null); // вводим переменную t3 как время
            foreach (string s in all_task3)
            {
                string[] dtimes = s.Split(':');
                bool proverka = true;
                foreach(string seconds in dtimes)
                {
                    if (proverka)
                    {
                        t3 = t3.AddMinutes(Convert.ToInt32(seconds));
                        proverka = false;
                    }
                    else t3 = t3.AddSeconds(Convert.ToInt32(seconds));
                    all_time = t3.ToString("mm:ss");
                }
                
                Console.WriteLine(all_time);
            }
            Console.ReadKey();
        }
    }
}
