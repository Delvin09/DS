using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib
{
    public class DoublyLinkedList : LinkedList
    {
        class DoublyLinkedListNode : LinkedListNode
        {
            public DoublyLinkedListNode? Prev { get; set; }

            public DoublyLinkedListNode(object value) : base(value)
            {
                Prev = null;
            }
        }

        protected override LinkedListNode CreateNode(object value, LinkedListNode? next = null, LinkedListNode? prev = null)
        {
            return new DoublyLinkedListNode(value)
            {
                Next = next,
                Prev = ((DoublyLinkedListNode?)prev)?.Prev
            };
        }

        protected override void UpdateNode(LinkedListNode node, LinkedListNode? next = null, LinkedListNode? prev = null, bool flagInsert = false)
        {
            ((DoublyLinkedListNode)node).Prev = (DoublyLinkedListNode?)prev;

            if (prev?.Next != null && flagInsert == true)
            {
                ((DoublyLinkedListNode)prev.Next).Prev = (DoublyLinkedListNode)node;
                base.UpdateNode(node, next, prev);
            }
            else
                base.UpdateNode(node, next, prev);

            if (node.Next == null && flagInsert == true)
                _last = node;
        }

        protected override bool RemoveNode(object value)
        {
            DoublyLinkedListNode? previous = null;
            var current = _first;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous == null)
                    {
                        _first = (DoublyLinkedListNode?)current.Next;

                        if (_first != null)
                            ((DoublyLinkedListNode)_first).Prev = null;
                        else
                            _last = null!;
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            _last = previous;
                        else
                            ((DoublyLinkedListNode)current.Next).Prev = previous;
                    }

                    Count--;
                    return true;
                }

                previous = (DoublyLinkedListNode)current;
                current = (DoublyLinkedListNode?)current.Next;
            }

            return false;
        }

        public void RemoveFirst()
        {
            if (_first == null)
                throw new InvalidOperationException("List is empty");

            _first = (DoublyLinkedListNode?)_first.Next;
            if (_first != null)
                ((DoublyLinkedListNode)_first).Prev = null;
            else
                _last = null;

            Count--;
        }

        public void RemoveLast()
        {
            if (_last == null)
                throw new InvalidOperationException("List is empty");

            _last = ((DoublyLinkedListNode)_last).Prev;
            if (_last != null)
                _last.Next = null;
            else
                _first = null;

            Count--;
        }
    }
}
