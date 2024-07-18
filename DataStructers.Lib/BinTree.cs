using DataStructers.Lib.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib
{
    class TreeNode<T>
    {
        public T Value { get; }
        public TreeNode<T>? Left { get; set; }
        public TreeNode<T>? Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinTree<T> : IBinaryTree<T>
        where T : IComparable<T>
    {
        private TreeNode<T>? Root { get; set; }

        T? IBinaryTree<T>.Root => Root != null ? Root.Value : default;

        public int Count { get; private set; }

        public BinTree()
        {
            Root = null;
            Count = 0;
        }

        public void Add(T value)
        {
            if (Root == null)
                Root = new TreeNode<T>(value);
            else
                RecursiveAdd(Root, value);

            Count++;
        }

        private void RecursiveAdd(TreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
                if (node.Left == null)
                    node.Left = new TreeNode<T>(value);
                else
                    RecursiveAdd(node.Left, value);
            else
                if (node.Right == null)
                node.Right = new TreeNode<T>(value);
            else
                RecursiveAdd(node.Right, value);
        }

        public bool Contains(T value)
        {
            return Contains(Root!, value);
        }

        private bool Contains(TreeNode<T> node, T value)
        {
            if (node == null)
                return false;

            if (node.Value.CompareTo(value) == 0)
                return true;
            else if (value.CompareTo(node.Value) < 0)
                return Contains(node.Left!, value);
            else
                return Contains(node.Right!, value);
        }

        public void Clear()
        {
            Root = null!;
            Count = 0;
        }

        public T[] ToArray()
        {
            var objects = new T[Count];
            return BFS(Root!, objects);
        }

        private T[] BFS(TreeNode<T> root, T[] array)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root), "The root node cannot be null.");

            var queue = new Queue();

            queue.Enqueue(root);

            var index = 0;

            while (queue.Count > 0)
            {
                var node = (TreeNode<T>)queue.Dequeue()!;
                array[index++] = node.Value!;

                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }

            return array;
        }

        public T?[] DFS()
        {
            var result = new List<T>();

            if (Root == null)
                return result.ToArray();

            DFSRecursive(Root!, result);

            return result.ToArray();
        }

        private void DFSRecursive(TreeNode<T> node, List<T> result)
        {
            if (node == null)
                return;

            result.Add(node.Value!);

            DFSRecursive(node.Left!, result);
            DFSRecursive(node.Right!, result);
        }
    }
}
