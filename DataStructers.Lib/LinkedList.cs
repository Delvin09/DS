using DataStructers.Lib.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructers.Lib
{
    public class LinkedList<T> : ILinkedList<T>, IEnumerable<T>
    {
        protected class LinkedListNode<T>
        {
            public T Value { get; }

            public LinkedListNode<T>? Next { get; set; }

            public LinkedListNode(T value)
            {
                Value = value;
                Next = null;
            }
        }

        protected LinkedListNode<T>? _first;
        protected LinkedListNode<T>? _last;

        public T? First => _first != null ? _first.Value : default;

        public T? Last => _last != null ? _last.Value : default;

        public int Count { get; protected set; }

        public LinkedList()
        {
            _first = null;
            _last = null;
            Count = 0;
        }

        protected virtual TNode CreateNode<TNode>(T value, LinkedListNode<T>? next = null, LinkedListNode<T>? prev = null)
            where TNode : LinkedListNode<T>
        {
            var newNode = new LinkedListNode<T>(value) { Next = next };
            return (TNode)newNode;
        }

        protected virtual void UpdateNode(LinkedListNode<T> node, LinkedListNode<T>? next = null, LinkedListNode<T>? prev = null, bool flagInsert = false)
        {
            prev!.Next = node;
        }

        public void Add(T value)
        {
            var newNode = CreateNode<LinkedListNode<T>>(value);

            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                UpdateNode(newNode, next: null, prev: _last);

                _last = newNode;
            }

            Count++;
        }

        public void AddFirst(T value)
        {
            var newNode = CreateNode<LinkedListNode<T>>(value);

            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                UpdateNode(_first, next: null, prev: newNode);
                _first = newNode;
            }

            Count++;
        }

        public virtual void Insert(int index, T value)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            var newNode = CreateNode<LinkedListNode<T>>(value);
            var currentIndex = 0;
            var current = _first;

            while (currentIndex < index - 1)
            {
                current = current!.Next;
                currentIndex++;

                if (current == null)
                    throw new IndexOutOfRangeException("Index is out of range.");
            }

            newNode.Next = current?.Next;
            UpdateNode(newNode, prev: current, flagInsert: true);

            Count++;
        }

        public bool Contains(object value)
        {
            if (_first == null)
                return false;
            else
            {
                if (_first.Value!.Equals(value) || _last!.Value!.Equals(value))
                    return true;
                else
                {
                    var currentNode = _first.Next;

                    while (currentNode != null)
                    {
                        if (currentNode.Value!.Equals(value))
                            return true;
                        currentNode = currentNode.Next;
                    }
                }
            }

            return false;
        }

        protected virtual bool RemoveNode(T value)
        {
            LinkedListNode<T>? prevNode = null;
            var current = _first;

            while (current != null)
            {
                if (current.Value!.Equals(value))
                {
                    if (_first!.Value!.Equals(value))
                    {
                        _first = current.Next;

                        if (_first == null)
                            _last = null;
                    }
                    else
                    {
                        prevNode!.Next = current.Next;

                        if (current.Next == null)
                            _last = prevNode;
                    }

                    Count--;
                    return true;
                }

                prevNode = current;
                current = current.Next;
            }

            return false;
        }

        public bool Remove(T value)
        {
            if (_first == null)
                throw new InvalidOperationException("List is empty");

            return RemoveNode(value);
        }

        public T[] ToArray()
        {
            var objects = new T[0];

            if (_first == null)
                return objects;

            objects = new T[Count];
            var currentNode = _first;
            var index = 0;
            while (currentNode != null)
            {
                objects[index++] = currentNode.Value!;
                currentNode = currentNode.Next;
            }

            return objects;
        }

        public void Clear()
        {
            _first = null;
            _last = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListIterator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LinkedListIterator<T> : IEnumerator<T>
        {
            private readonly LinkedList<T> list;
            private LinkedList<T>.LinkedListNode<T>? currentNode = null;

            public T Current { get => currentNode != null ? currentNode.Value : default; }

            object IEnumerator.Current => Current;

            public LinkedListIterator(LinkedList<T> list)
            {
                this.list = list;
            }

            public bool MoveNext()
            {
                if (currentNode == null)
                {
                    currentNode = list._first;
                }
                else
                {
                    currentNode = currentNode.Next;
                }

                return currentNode != null;
            }

            public void Reset()
            {
                currentNode = null;
            }

            public void Dispose()
            {
            }
        }
    }
}
