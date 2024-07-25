using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib
{
    public class Queue<T> : IEnumerable<T>
    {
        private class QueueNode
        {
            public T? Value { get; }
            public QueueNode? Next { get; set; }

            public QueueNode(T? value)
            {
                Value = value;
                Next = null;
            }
        }

        private QueueNode? _head;
        private QueueNode? _tail;
        public int Count { get; private set; }

        public Queue()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public void Enqueue(T? value)
        {
            var newNode = new QueueNode(value);

            if (_tail == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }

            Count++;
        }

        public T? Dequeue()
        {
            if (_head == null)
                throw new InvalidOperationException("Queue is empty");


            var deQueueElement = _head.Value;
            _head = _head.Next;
            Count--;

            if (_head == null)
                _tail = null;

            return deQueueElement;
        }

        public bool Contains(T? value)
        {
            return Count > 0 && Contains(_head!, value);
        }

        private bool Contains(QueueNode current, T? value)
        {
            while (current != null)
            {
                if (current.Value!.Equals(value))
                    return true;

                current = current.Next!;
            }

            return false;
        }

        public T? Peek()
        {
            if (_head == null)
                throw new InvalidOperationException("Queue is empty");

            return _head.Value;
        }

        public T?[] ToArray()
        {
            if (_head == null)
                return new T?[0];

            var objects = new T?[Count];
            var current = _head;
            var index = 0;

            while (current != null)
            {
                objects[index++] = current.Value;
                current = current.Next;
            }

            return objects;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
