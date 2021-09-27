using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GenericCollection<T> : IEnumerator<T>, IEnumerable<T>
    {
        List<T> collection;
        int current=-1;
        T _current;
        public GenericCollection()
        {
            collection = new List<T>();
        }
        public GenericCollection(List<T> obj)
        {
            collection = new List<T>();
            collection.AddRange(obj);
        }
        public void AddEl (T el)
        {
            collection.Add(el);
        }
        public void DelEl(int el)
        {
            try
            {
                collection.RemoveAt(el);
            }
            catch(Exception)
            {
                Console.WriteLine("Error");
            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()//
        {
            current = -1;
            return this;
        }

        public IEnumerator GetEnumerator()//
        {
            current = -1;
            return this;
        }
        void IDisposable.Dispose()
        {

        }
        bool IEnumerator.MoveNext()
        {
            if (collection.Count == 0)
            {
                return false;
            }
            if (collection.Count - 1 > current)
            {
                current++;
                return true;
            }
            else return false;
        }
        void IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }
        T IEnumerator<T>.Current => _current ;

        object IEnumerator.Current
        {
            get { return collection[current]; }
        }
    }
}
