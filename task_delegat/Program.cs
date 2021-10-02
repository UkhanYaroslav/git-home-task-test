using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingLINQ
{
    class Program
    {
        delegate void deleg(string x);
        public delegate void Notify();//delegate for event    
        public delegate void Action_del(string s);
        static void Main(string[] args)
        {
            string str;
            while (true)
            {
                Console.Write("1.Event   2.Delegate   " + @"3.Action" + "\nYour choose:");
                string choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        class_event class_Event = new class_event();
                        while (true)
                        {
                            str = Console.ReadLine();
                            class_Event.StartEvent(str);
                        }
                    case "2":
                        deleg d1 = AlphaNumericCollector.method;
                        deleg d2 = StringCollector.unn;
                        while (true)
                        {
                            str = Console.ReadLine();
                            if (WithNumber(str))
                            {
                                d1(str);
                            }
                            else
                            {
                                d2(str);
                            }
                        }
                    case "3":
                        Action_del act_del = Action_method;
                        while (true)
                        {
                            str = Console.ReadLine();
                            act_del(str);
                        }
                    default: Console.WriteLine("Error.Try again"); break;
                }
            }
        }
        public static bool WithNumber(string stri)//проверка на наличие чисел в строке
        {
            foreach (char c in stri)
            {
                if (c >= '0' && c <= '9')
                {
                    return true;
                }
            }
            return false;
        }
        public static class AlphaNumericCollector//коллекция со строками с числами
        {
            static List<string> num = new List<string>();

            public static void method(string x)
            {
                num.Add(x);
            }
        }
        static class StringCollector //коллекция со строками без чисел
        {
            static List<string> unnum = new List<string>();
            public static void unn(string x)
            {
                unnum.Add(x);
            }
        }
        public class class_event//Event_class
        {
            public event Notify event_deleg;
            public void StartEvent(string str)
            {
                if (WithNumber(str))
                {
                    AlphaNumericCollector.method(str);
                }
                else
                {
                    StringCollector.unn(str);
                }
                OnProcessCompleted();
            }
            protected virtual void OnProcessCompleted()
            {
                event_deleg?.Invoke();
            }
        }
        static void Action_method(string s) //action method
        {
            if (WithNumber(s))
            {
                AlphaNumericCollector.method(s);
            }
            else
            {
                StringCollector.unn(s);
            }
        }
    }
}
