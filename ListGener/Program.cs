using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            GenericCollection<Interface1> collection = new GenericCollection<Interface1>();

            Class1 first1 = new Class1() { name = "filip", age = 12 };
            Class1 first2 = new Class1() { name = "Oleg", age = 20 };
            Class2 second1 = new Class2() { name = "Lina", surname = "Malik" };
            Class2 second2 = new Class2() { name = "Maks", surname = "Tris" };

            collection.AddEl(first1);
            collection.AddEl(first2);
            collection.AddEl(second1);
            collection.AddEl(second2);

            foreach (Interface1 obj in collection)
            {
                Console.WriteLine(obj.name);
            }
            Console.WriteLine();
            foreach (Interface1 obj in collection)
            {
                if (obj.name == "Lina")
                {
                    Console.WriteLine("Name Lisa = true");
                }
                else
                {
                    Console.WriteLine("Name Lisa = false");
                }
            }
        }
    }
}
