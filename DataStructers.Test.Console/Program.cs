using DataStructers.Lib;
using System;
using System.Collections;

namespace DataStructers.Test
{
    interface IContainer<T> : IContainerGet<T>, IContainerSet<T>
    {

    }

    interface IContainerGet<out T>
    {
        T? Get();
    }

    interface IContainerSet<in T>
    {
        void Set(T? item);
    }

    class Container<T> : IContainer<T>
    {
        private T? _item = default;

        public T? Get()
        {
            return _item;
        }

        public void Set(T? item)
        {
            //if (ValidateItem(item))
                _item = item;
        }

        //private bool ValidateItem(T? item)
        //{
        //    return item == null || ValidateType(item);
        //}

        //protected virtual bool ValidateType(T item)
        //{
        //    return true;
        //}
    }

    struct My<T>
    {
        private readonly T _item;
    }

    interface IMy<T>
    {
        T Value { get; }
    }

    class ViewItem
    {
        // element on the ui
    }

    class VA { }

    class DocumentViewItem<T> : ViewItem where T : FileItem, new()
    {
        T File { get; set; }

        public void Do()
        {
            T variable = new T();
        }
    }

    class ImageViewItem<T> : ViewItem
    {
        T File { get; set; }
    }


    class FileItem
    {
        public byte[] Content { get; set; }
    }

    class DocxFile : FileItem
    {

    }

    class PdfFile : FileItem
    {

    }

    class PngFile : FileItem
    {

    }

    static class LinkedListExtensions
    {
        public static List<object> ToList(this LinkedList linkedList)
        {
            return linkedList.ToArray().ToList();
        }
    }

    class Order { }

    interface IDatabaseConnection : IDisposable { }

    class Product : IComparable<Product>, IComparable<int>, IDisposable
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

        public int CompareTo(int other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Product? other)
        {
            throw new NotImplementedException();
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

    class Pet { }
    class Dog : Pet { }
    class Cat : Pet { }

    internal class Program
    {
        static void Main(string[] args)
        {
            Container<object> container = new Container<object>();
            Container<Pet> petContainer = new Container<Pet>();
            Container<Dog> dogCont = new Container<Dog>();
            Container<Cat> catCont = new Container<Cat>();

            Cat cat = new Cat();
            Pet pet = cat;

            IContainerSet<Dog> petContGet = petContainer;
            //petContGet = dogCont;

            Container<int> intConteiner = new Container<int>();
            Container<Product> productContainer = new Container<Product>();

            container.Set("asdasd");
            intConteiner.Set(34234);
            container.Set(true);
            productContainer.Set(new Product());

            using Product p = new Product();
            
                //.........
             // p.Dispose();


            var comp = new ProductComparer();
            var ll = new LinkedList();
            var newList = ll.ToList();

            DateTime? dateTime = null;
            DateTime dateTime1 = DateTime.Now;
            
            DateTimeOffset dateTime2 = DateTimeOffset.Now;
        }
    }
}
