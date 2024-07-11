using DataStructers.Lib;
using System;
using System.Collections;

namespace DataStructers.Test
{
    static class LinkedListExtensions
    {
        public static List<object> ToList(this LinkedList linkedList)
        {
            return linkedList.ToArray().ToList();
        }
    }

    class Order { }

    interface IDatabaseConnection : IDisposable { }

    class Product : IComparable, IDisposable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        private IDatabaseConnection databaseConnection;
        private bool _disposed;

        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else if (obj is Product product)
            {
                return this.Id - product.Id;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        ~Product()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            _disposed = true;

            if (disposing)
            {
                // не фіналізатор
            }
            else
            {
                // фіналізатор
            }

            databaseConnection.Dispose();
        }
    }

    class ProductComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }
            else if (x is Product product1 && y is Product product2)
            {
                return product1.Id - product2.Id;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using Product p = new Product();
            
                //.........
             // p.Dispose();


            var comp = new ProductComparer();
            var ll = new LinkedList();
            var newList = ll.ToList();
            var btt = CreateTree(comp);

            DateTime? dateTime = null;
            DateTime dateTime1 = DateTime.Now;
            
            DateTimeOffset dateTime2 = DateTimeOffset.Now;

            BinaryTree CreateTree(IComparer comparer)
            {
                var bt = new BinaryTree(comparer);
                bt.Add(new Product { Id = 1, Name = "1" });
                bt.Add(new Product { Id = 1, Name = "1" });
                bt.Add(new Product { Id = 1, Name = "1" });
                return bt;
            }
        }
    }
}
