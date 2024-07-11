using DataStructers.Lib.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib
{
    class TreeNode
    {
        public int Value { get; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree : IBinaryTree
    {
        private TreeNode? Root { get; set; }

        object? IBinaryTree.Root => Root?.Value;

        public int Count { get; private set; }

        

        public BinaryTree()
        {
            Root = null;
            Count = 0;
        }


        public void Add(int value)
        {
            if (Root == null)
                Root = new TreeNode(value);
            else
                RecursiveAdd(Root, value);

            Count++;
        }

        private void RecursiveAdd(TreeNode node, int value)
        {
            if (value < node.Value)
                if (node.Left == null)
                    node.Left = new TreeNode(value);
                else
                    RecursiveAdd(node.Left, value);
            else
                if (node.Right == null)
                node.Right = new TreeNode(value);
            else
                RecursiveAdd(node.Right, value);
        }

        public bool Contains(int value)
        {
            return Contains(Root!, value);
        }

        private bool Contains(TreeNode node, int value)
        {
            if (node == null)
                return false;

            if (node.Value.Equals(value))
                return true;
            else if (value < node.Value)
                return Contains(node.Left!, value);
            else
                return Contains(node.Right!, value);
        }

        private int MinValue(TreeNode node)
        {
            int minValue = node.Value;
            while (node.Left != null)
            {
                minValue = node.Left.Value;
                node = node.Left;
            }
            return minValue;
        }

        public void Clear()
        {
            Root = null!;
            Count = 0;
        }

        //public object[] DFS()
        //{
        //    var result = new List();

        //    if (Root == null)
        //        return result.ToArray();

        //    DFSRecursive(Root, result);

        //    return result.ToArray();
        //}

        //private void DFSRecursive(TreeNode node, List result)
        //{
        //    if (node == null)
        //        return;

        //    result.Add(node.Value);

        //    DFSRecursive(node.Left!, result);
        //    DFSRecursive(node.Right!, result);
        //}

        public object[] ToArray()
        {
            var objects = new object[Count];
            return BFS(Root!, objects);
        }

        private object[] BFS(TreeNode root, object[] array)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root), "The root node cannot be null.");

            var queue = new Queue();

            queue.Enqueue(root);

            var index = 0;

            while (queue.Count > 0)
            {
                var node = (TreeNode)queue.Dequeue();
                array[index++] = node.Value;

                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }

            return array;
        }
    }
}
