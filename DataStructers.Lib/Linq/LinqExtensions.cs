using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib.Linq
{
    public static class LinqExtensions
    {
        private class FilterEnumerable<T> : IEnumerable<T>
        {
            private readonly IEnumerable<T> collection;
            private readonly Predicate<T> predicate;

            public FilterEnumerable(IEnumerable<T> collection, Predicate<T> predicate)
            {
                this.collection = collection;
                this.predicate = predicate;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new FilterEnumerator<T>(collection, predicate);
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class FilterEnumerator<T> : IEnumerator<T>
        {
            private IEnumerator<T> collection;
            private Predicate<T> predicate;

            public FilterEnumerator(IEnumerable<T> collection, Predicate<T> predicate)
            {
                this.collection = collection.GetEnumerator();
                this.predicate = predicate;
            }

            public T Current => collection.Current;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                bool result = false;
                do
                {
                    result = collection.MoveNext();
                }
                while (result && !predicate(Current));
                return result;
            }

            public void Reset()
            {
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            //var list = new List<T>();
            //foreach (var item in collection)
            //{
            //    if (predicate(item))
            //    {
            //        list.Add(item);
            //    }
            //}
            //return list;
            return new FilterEnumerable<T>(collection, predicate);
        }

        public static IEnumerable<T> Get<T>(this IEnumerable<T> collection, int count)
        {
            foreach (T item in collection)
            {
                count--;
                if (count >= 0)
                    yield return item;
                else
                    yield break;
            }
        }
    }
}
