using CustomList = DataStructers.Lib.List;
using CustomBinaryTree = DataStructers.Lib.BinTree;
using CustomQueue = DataStructers.Lib.Queue;
using CustomStack = DataStructers.Lib.Stack;
using CustomLinkedList = DataStructers.Lib.LinkedList;
using CustomDoublyLinkedList = DataStructers.Lib.DoublyLinkedList;

namespace DataStructers.Test
{
    internal class OldTests
    {
        public static void Run()
        {
            TestList();

            TestBinaryTree();

            TestQueue();

            TestStack();

            TestLinkedList();

            TestDoublyLinkedList();
        }

        static void TestList()
        {
            CustomList list = new CustomList(9);

            AddElementsToList(list);

            TestListContains(list);

            TestListInsert(list);

            TestListReverse(list);

            TestListRemove(list);

            TestListRemoveAt(list);

            TestListIndexOf(list);

            TestListToArray(list);

            TestListClear(list);
        }

        static void AddElementsToList(CustomList list)
        {
            list.Add(10);
            list.Add("10");
            list.Add('c');
            list.Add(10.2);
            list.Add("end");

            System.Console.Write("List: ");
            PrintList(list);
            System.Console.WriteLine();
        }

        static void TestListContains(CustomList list)
        {
            var num = list.Contains(10);
            System.Console.WriteLine($"List contains 10: {num}");
            System.Console.WriteLine();
        }

        static void TestListInsert(CustomList list)
        {
            list.Insert(0, "111");
            System.Console.WriteLine("List after inserting '111' at index 0:");
            PrintList(list);
            System.Console.WriteLine();
        }

        static void TestListReverse(CustomList list)
        {
            list.Reverse();
            System.Console.WriteLine("List after reversing:");
            PrintList(list);
            System.Console.WriteLine();
        }

        static void TestListRemove(CustomList list)
        {
            list.Remove(10);
            System.Console.WriteLine("List after removing '10':");
            PrintList(list);
            System.Console.WriteLine();
        }

        static void TestListRemoveAt(CustomList list)
        {
            list.RemoveAt(3);
            System.Console.WriteLine("List after removing element at index 3:");
            PrintList(list);
            System.Console.WriteLine();
        }

        static void TestListIndexOf(CustomList list)
        {
            var index = list.IndexOf("end");
            System.Console.WriteLine($"Index of 'end' in the list: {index}");
            System.Console.WriteLine();
        }

        static void TestListToArray(CustomList list)
        {
            var array = list.ToArray();
            System.Console.WriteLine("List converted to array:");
            PrintArrayMethodList(array);
            System.Console.WriteLine();
        }

        static void TestListClear(CustomList list)
        {
            list.Clear();
            System.Console.WriteLine("List cleared.");
            if (list.Count == 0)
            {
                System.Console.WriteLine("This list is empty!");
            }
            else
            {
                System.Console.WriteLine("List elements after clearing:");
                PrintList(list);
            }
            System.Console.WriteLine();
        }

        static void PrintList(CustomList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine();
        }

        static void PrintArrayMethodList(object[] array)
        {
            foreach (var item in array)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine();
        }


        static void TestBinaryTree()
        {
            CustomBinaryTree tree = new CustomBinaryTree();

            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(3);
            tree.Add(7);
            tree.Add(12);
            tree.Add(17);

            System.Console.Write("Binary tree: ");

            var array = tree.ToArray();

            foreach (var item in array)
            { System.Console.Write(item + " "); }

            System.Console.WriteLine("\n");

            TestBinaryTreeContains(tree);

            TestBinaryTreeDFS(tree);

            TestBinaryTreeBFS(tree);

            TestBinaryTreeClear(tree);
        }

        static void TestBinaryTreeContains(CustomBinaryTree tree)
        {
            System.Console.WriteLine($"Contains 10: {tree.Contains(10)}"); // True
            System.Console.WriteLine($"Contains 7: {tree.Contains(7)}");   // True
            System.Console.WriteLine($"Contains 20: {tree.Contains(20)}"); // False
            System.Console.WriteLine();
        }

        static void TestBinaryTreeDFS(CustomBinaryTree tree)
        {
            System.Console.WriteLine("DFS Traversal:");
            foreach (var value in tree.DFS())
            {
                System.Console.Write(value + " ");
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
        }

        static void TestBinaryTreeBFS(CustomBinaryTree tree)
        {
            System.Console.WriteLine("BFS Traversal:");
            foreach (var value in tree.ToArray())
            {
                System.Console.Write(value + " ");
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
        }

        static void TestBinaryTreeClear(CustomBinaryTree tree)
        {
            tree.Clear();
            System.Console.WriteLine("Tree cleared");
            System.Console.WriteLine($"Tree count: {tree.Count}");
            System.Console.WriteLine();
        }


        static void TestQueue()
        {
            CustomQueue queue = new CustomQueue();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            TestQueueToArray(queue);

            TestQueueCount(queue);

            TestQueueContains(queue);

            TestQueuePeek(queue);

            TestQueueDequeue(queue);

            TestQueueToArray(queue);

            TestQueueClear(queue);
        }

        static void TestQueueCount(CustomQueue queue)
        {
            System.Console.WriteLine("Count: " + queue.Count); // Output: Count: 3
            System.Console.WriteLine();
        }

        static void TestQueueContains(CustomQueue queue)
        {
            System.Console.WriteLine("Contains 2: " + queue.Contains(2)); // Output: Contains 2: True
            System.Console.WriteLine("Contains 4: " + queue.Contains(4)); // Output: Contains 4: False
            System.Console.WriteLine();
        }

        static void TestQueuePeek(CustomQueue queue)
        {
            System.Console.WriteLine("Peek: " + queue.Peek()); // Output: Peek: 1
            System.Console.WriteLine();
        }

        static void TestQueueDequeue(CustomQueue queue)
        {
            System.Console.WriteLine("Dequeue: " + queue.Dequeue()); // Output: Dequeue: 1
            System.Console.WriteLine();
        }

        static void TestQueueToArray(CustomQueue queue)
        {
            var array = queue.ToArray();
            System.Console.WriteLine("Queue to Array: " + string.Join(", ", array)); // Output: Queue to Array: 2, 3
            System.Console.WriteLine();
        }

        static void TestQueueClear(CustomQueue queue)
        {
            queue.Clear();
            System.Console.WriteLine("Count after Clear: " + queue.Count); // Output: Count after Clear: 0
            System.Console.WriteLine();
        }


        static void TestStack()
        {
            CustomStack stack = new CustomStack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            TestStackToArray(stack);

            TestStackCount(stack);

            TestStackContains(stack);

            TestStackPeek(stack);

            TestStackPop(stack);

            TestStackToArray(stack);

            TestStackClear(stack);
        }

        static void TestStackCount(CustomStack stack)
        {
            System.Console.WriteLine("Count: " + stack.Count); // Output: Count: 3
            System.Console.WriteLine();
        }

        static void TestStackContains(CustomStack stack)
        {
            System.Console.WriteLine("Contains 2: " + stack.Contains(2)); // Output: Contains 2: True
            System.Console.WriteLine("Contains 4: " + stack.Contains(4)); // Output: Contains 4: False
            System.Console.WriteLine();
        }

        static void TestStackPeek(CustomStack stack)
        {
            System.Console.WriteLine("Peek: " + stack.Peek()); // Output: Peek: 3
            System.Console.WriteLine();
        }

        static void TestStackPop(CustomStack stack)
        {
            System.Console.WriteLine("Pop: " + stack.Pop()); // Output: Pop: 3
            System.Console.WriteLine();
        }

        static void TestStackToArray(CustomStack stack)
        {
            var array = stack.ToArray();
            System.Console.WriteLine("Stack to Array: " + string.Join(", ", array)); // Output: Stack to Array: 2, 1
            System.Console.WriteLine();
        }

        static void TestStackClear(CustomStack stack)
        {
            stack.Clear();
            System.Console.WriteLine("Count after Clear: " + stack.Count); // Output: Count after Clear: 0
            System.Console.WriteLine();
        }


        static void TestLinkedList()
        {
            var linkedList = new CustomLinkedList();

            linkedList.Add(10);
            linkedList.Add(20);
            linkedList.Add(30);

            TestPrintLinkedList(linkedList);

            linkedList.AddFirst(5);

            TestPrintLinkedList(linkedList);

            linkedList.Insert(2, 15);

            TestPrintLinkedList(linkedList);

            // Contains
            int searchValue = 15;
            System.Console.WriteLine($"\nList contains {searchValue}: {linkedList.Contains(searchValue)}");
            System.Console.WriteLine();

            // Clear
            linkedList.Clear();
            System.Console.WriteLine("List cleared.");

            TestPrintLinkedList(linkedList);
        }

        static void TestPrintLinkedList(CustomLinkedList linkedList)
        {
            System.Console.WriteLine("Elements in the list:");
            PrintArrayMethodLinkedList(linkedList.ToArray());
            System.Console.WriteLine();
        }

        static void PrintArrayMethodLinkedList(object[] array)
        {
            foreach (var item in array)
            {
                System.Console.Write($"{item} ");
            }
            System.Console.WriteLine();
        }


        static void TestDoublyLinkedList()
        {
            var doublyLinkedList = new CustomDoublyLinkedList();

            TestDoublyLinkedListAdd(doublyLinkedList);
            TestDoublyLinkedListRemove(doublyLinkedList);
            TestDoublyLinkedListInsert(doublyLinkedList);
            TestDoublyLinkedListContains(doublyLinkedList);
            TestDoublyLinkedListClear(doublyLinkedList);
        }

        static void TestDoublyLinkedListAdd(CustomDoublyLinkedList list)
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            PrintListMethodDoublyLinkedList(list);
        }

        static void TestDoublyLinkedListRemove(CustomDoublyLinkedList list)
        {
            System.Console.WriteLine("Removing element 3 from the list...");
            list.Remove(3);
            PrintListMethodDoublyLinkedList(list);

            System.Console.WriteLine("Removing the first element from the list...");
            list.RemoveFirst();
            PrintListMethodDoublyLinkedList(list);

            System.Console.WriteLine("Removing the last element from the list...");
            list.RemoveLast();
            PrintListMethodDoublyLinkedList(list);
        }

        static void TestDoublyLinkedListInsert(CustomDoublyLinkedList list)
        {
            System.Console.WriteLine("Inserting element 10 at index 1...");
            list.Insert(1, 10);
            PrintListMethodDoublyLinkedList(list);
        }

        static void TestDoublyLinkedListContains(CustomDoublyLinkedList list)
        {
            System.Console.WriteLine("Checking if 3 is in the list: " + list.Contains(3));
            System.Console.WriteLine("Checking if 10 is in the list: " + list.Contains(10));
            System.Console.WriteLine();
        }

        static void TestDoublyLinkedListClear(CustomDoublyLinkedList list)
        {
            System.Console.WriteLine("Clearing the list...");
            list.Clear();
            System.Console.WriteLine("List cleared. Count: " + list.Count);
            System.Console.WriteLine();
        }

        static void PrintListMethodDoublyLinkedList(CustomDoublyLinkedList list)
        {
            System.Console.Write("List elements: ");
            var array = list.ToArray();
            foreach (var element in array)
            {
                System.Console.Write(element + " ");
            }
            System.Console.WriteLine("\n");
        }
    }
}
