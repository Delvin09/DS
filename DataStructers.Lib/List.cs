using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib
{
    public class List
    {
        private const int DefaultCapacity = 4;
        private object?[] _objects;

        public int Count { get; private set; }

        public int Capacity { get => _objects.Length; }

        public object? this[int index]
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
            _objects = new object?[DefaultCapacity];
            Count = 0;
        }

        public List(int capacity)
        {
            _objects = new object?[capacity];
            Count = 0;
        }

        private void Resize(int capacity)
        {
            if (capacity > _objects.Length)
            {
                var newCapacity = _objects.Length * 2;
                var newObjects = new object?[newCapacity];
                _objects.CopyTo(newObjects, 0);
                _objects = newObjects;
            }
        }

        public void Add(object? obj)
        {
            Resize(Count + 1);
            _objects[Count++] = obj;
        }

        public void Insert(int index, object? obj)
        {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException();

            Resize(Count + 1);

            for (var i = Count; i > index; i--)
                _objects[i] = _objects[i - 1];

            _objects[index] = obj;
            Count++;
        }

        public bool Remove(object? obj)
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
            _objects = new object?[DefaultCapacity];
            Count = 0;
        }

        public bool Contains(object? obj)
        {
            if (_objects == null)
                return false;

            return IndexOf(obj!) >= 0 ? true : false;
        }

        public int IndexOf(object? obj)
        {
            for (var i = 0; i < Count; i++)
                if (_objects[i]!.Equals(obj))
                    return i;
            return -1;
        }

        public object?[] ToArray()
        {
            var array = new object?[Count];

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
    }
}
