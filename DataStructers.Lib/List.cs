using DataStructers.Lib.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib
{
    public class List<T> : Interfaces.ICollection<T>, IEnumerable<T>
    {
        private const int DefaultCapacity = 4;
        private T?[] _objects;

        public int Count { get; private set; }

        public int Capacity { get => _objects.Length; }

        public T? this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                    throw new IndexOutOfRangeException();
                return _objects[index];
            }

            set
            {
                if (index < 0 || index > Count)
                    throw new IndexOutOfRangeException();
                _objects[index] = value;
            }
        }

        public List()
        {
            _objects = new T?[DefaultCapacity];
            Count = 0;
        }

        public List(int capacity)
        {
            _objects = new T?[capacity];
            Count = 0;
        }

        private void Resize(int capacity)
        {
            if (capacity > _objects.Length)
            {
                var newCapacity = _objects.Length * 2;
                var newObjects = new T?[newCapacity];
                _objects.CopyTo(newObjects, 0);
                _objects = newObjects;
            }
        }

        public void Add(T? obj)
        {
            Resize(Count + 1);
            _objects[Count++] = obj;
        }

        public void Insert(int index, T? obj)
        {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException();

            Resize(Count + 1);

            for (var i = Count; i > index; i--)
                _objects[i] = _objects[i - 1];

            _objects[index] = obj;
            Count++;
        }

        public bool Remove(T? obj)
        {
            var index = IndexOf(obj);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            for (var i = index; i < Count - 1; i++)
            {
                _objects![i] = _objects[i + 1];
            }
            Count--;
            _objects[Count] = default!;
        }

        public void Clear()
        {
            _objects = new T?[DefaultCapacity];
            Count = 0;
        }

        public bool Contains(T? obj)
        {
            if (_objects == null)
                return false;

            return IndexOf(obj!) >= 0 ? true : false;
        }

        public int IndexOf(T? obj)
        {
            for (var i = 0; i < Count; i++)
                if (_objects[i]!.Equals(obj))
                    return i;
            return -1;
        }

        public T?[] ToArray()
        {
            var array = new T?[Count];

            for (var i = 0; i < Count; i++)
                array[i] = _objects![i];

            return array;
        }

        public void Reverse()
        {
            for (var i = 0; i < Count / 2; i++)
            {
                var temp = _objects![i];
                _objects[i] = _objects[Count - i - 1];
                _objects[Count - i - 1] = temp;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListIterator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ListIterator<T> : IEnumerator<T>
        {
            private readonly List<T> list;
            private int currentIndex = -1;

            public T Current => list[currentIndex];

            object IEnumerator.Current => Current;

            public ListIterator(List<T> list)
            {
                this.list = list;
            }

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < list.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
