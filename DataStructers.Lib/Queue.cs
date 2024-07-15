using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib
{
    public class Queue
    {
        private class QueueNode
        {
            public object? Value { get; }
            public QueueNode? Next { get; set; }

            public QueueNode(object? value)
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

        public void Enqueue(object? value)
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

        public object? Dequeue()
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

        public bool Contains(object? value)
        {
            return Count > 0 && Contains(_head!, value);
        }

        private bool Contains(QueueNode current, object? value)
        {
            while (current != null)
            {
                if (current.Value!.Equals(value))
                    return true;

                current = current.Next!;
            }

            return false;
        }

        public object? Peek()
        {
            if (_head == null)
                throw new InvalidOperationException("Queue is empty");

            return _head.Value;
        }

        public object?[] ToArray()
        {
            if (_head == null)
                return new object?[0];

            var objects = new object?[Count];
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
    }
}
