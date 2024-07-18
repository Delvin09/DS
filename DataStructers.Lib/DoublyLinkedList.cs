using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib
{
    public class DoublyLinkedList<T> : LinkedList<T>
    {
        class DoublyLinkedListNode<T> : LinkedListNode<T>
        {
            public DoublyLinkedListNode<T>? Prev { get; set; }

            public DoublyLinkedListNode(T value) : base(value)
            {
                Prev = null;
            }
        }

        protected override TNode CreateNode<TNode>(T value, LinkedListNode<T>? next = null, LinkedListNode<T>? prev = null)
        {
            LinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value)
            {
                Next = next,
                Prev = (DoublyLinkedListNode<T>?)prev
            };
            return (TNode)newNode;
        }

        protected override void UpdateNode(LinkedListNode<T> node, LinkedListNode<T>? next = null, LinkedListNode<T>? prev = null, bool flagInsert = false)
        {
            ((DoublyLinkedListNode<T>)node).Prev = (DoublyLinkedListNode<T>?)prev;

            if (prev?.Next != null && flagInsert == true)
            {
                ((DoublyLinkedListNode<T>)prev.Next).Prev = (DoublyLinkedListNode<T>)node;
                base.UpdateNode(node, next, prev);
            }
            else
                base.UpdateNode(node, next, prev);

            if (node.Next == null && flagInsert == true)
                _last = node;
        }

        protected override bool RemoveNode(T value)
        {
            DoublyLinkedListNode<T>? previous = null;
            var current = _first;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous == null)
                    {
                        _first = (DoublyLinkedListNode<T>?)current.Next;

                        if (_first != null)
                            ((DoublyLinkedListNode<T>)_first).Prev = null;
                        else
                            _last = null!;
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            _last = previous;
                        else
                            ((DoublyLinkedListNode<T>)current.Next).Prev = previous;
                    }

                    Count--;
                    return true;
                }

                previous = (DoublyLinkedListNode<T>)current;
                current = (DoublyLinkedListNode<T>?)current.Next;
            }

            return false;
        }

        public void RemoveFirst()
        {
            if (_first == null)
                throw new InvalidOperationException("List is empty");

            _first = (DoublyLinkedListNode<T>?)_first.Next;
            if (_first != null)
                ((DoublyLinkedListNode<T>)_first).Prev = null;
            else
                _last = null;

            Count--;
        }

        public void RemoveLast()
        {
            if (_last == null)
                throw new InvalidOperationException("List is empty");

            _last = ((DoublyLinkedListNode<T>)_last).Prev;
            if (_last != null)
                _last.Next = null;
            else
                _first = null;

            Count--;
        }
    }
}
