using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib
{
    public class Stack
    {
        private class StackNode
        {
            public object? Value { get; }
            public StackNode? Next { get; set; }

            public StackNode(object? value)
            {
                Value = value;
                Next = null;
            }
        }

        private StackNode? _top;
        public int Count { get; private set; }

        public Stack()
        {
            _top = null;
            Count = 0;
        }

        public void Push(object? value)
        {
            var node = new StackNode(value);

            if (_top == null)
                _top = node;
            else
            {
                node.Next = _top;
                _top = node;
            }

            Count++;
        }

        public object? Pop()
        {
            if (_top == null)
                throw new InvalidOperationException("Stack is empty");

            var poppedElement = _top.Value;
            _top = _top.Next;
            Count--;

            return poppedElement;
        }

        public object? Peek()
        {
            if (_top == null)
                throw new InvalidOperationException("Stack is empty");

            return _top.Value;
        }

        public bool Contains(object? value)
        {
            if (_top == null)
                return false;
            else
            {
                var current = _top;

                while (current != null)
                {
                    if (current.Value!.Equals(value))
                        return true;
                    current = current.Next;
                }
            }

            return false;
        }

        public object?[] ToArray()
        {
            if (_top == null)
                return Array.Empty<object?>();

            var objects = new object?[Count];
            var current = _top;
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
            _top = null;
            Count = 0;
        }
    }
}
