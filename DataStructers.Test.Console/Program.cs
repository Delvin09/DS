using DataStructers.Lib;
using DataStructers.Lib.Interfaces;
using System;
using DataStructers.Lib.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace DataStructers.Test
{
    class MyClass
    {
        private int someField;
        private bool Bar() { return false; }

        public Func<int, int> Run()
        {
            return Foo;
        }

        private Action Process(Func<int, string, int> whenDone, Func<int, string, int> whenError)
        {
            //....
            var result = whenDone(10, "Callback call");
            //....

            var f = () =>
            {
                Console.WriteLine(someField);
            };
            return f;
        }

        private int Foo(int x)
        {
            Console.WriteLine($"{x} - ");
            return x;
        }

        private int M1(int x, string msg)
        {
            Console.WriteLine($"{x} - {msg}");
            return 0;
        }
    }

    class FileLogger
    {
        public void SaveTestResult(object sender, EventArgs eventArgs)
        {

        }

        public void StartTestGroup(string testGroupName)
        {
        }
    }


    class ReportStorage : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class SomeClass
    {
        public IEnumerable<int> GetInts()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
        }
    }

    abstract class Pizza
    {

        protected Lib.List<string> ingredients = new Lib.List<string>();
        protected string pizzaBase;

        public int Size { get; }

        public double Weight { get; }


        public abstract void Prepare();

        public void AddIngr(string ing)
        {
            ingredients.Add(ing);
        }
    }

    class ItalianPizza : Pizza
    {
        public override void Prepare()
        {
            Console.WriteLine("Основа пици");
            pizzaBase = "тонка";
            ingredients.Add("соус маргарита");
        }
    }

    class American : Pizza
    {
        public override void Prepare()
        {
            Console.WriteLine("Основа пици");
            pizzaBase = "товста";
            ingredients.Add("кетчуп");
        }
    }


    class CheesePizzaDecorator : Pizza
    {
        private readonly Pizza pizza;
        private readonly string cheeseName;

        public CheesePizzaDecorator(Pizza pizza, string cheeseName)
        {
            this.pizza = pizza;
            this.cheeseName = cheeseName;
        }

        public override void Prepare()
        {
            Console.WriteLine($"додання сиру {cheeseName}");
            pizza.AddIngr(cheeseName);
            pizza.Prepare();
        }
    }

    class MeatPizzaDecorator : Pizza
    {
        private readonly Pizza pizza;
        private readonly string meatName;

        public MeatPizzaDecorator(Pizza pizza, string meatName)
        {
            this.pizza = pizza;
            this.meatName = meatName;
        }

        public override void Prepare()
        {
            Console.WriteLine($"додання мяса {meatName}");
            pizza.AddIngr(meatName);
            pizza.Prepare();
        }
    }


    struct Point
    {
        public int x; public int y;
    }


    struct KeyForDict
    {
        public string Name { get; set; }
        public int Age { get; set; }

        //public override bool Equals(object? obj)
        //{
        //    if (obj == null) return false;
        //    if (obj == this) return true;
        //    if (obj is not KeyForDict key) return false;

        //    return key.Name.Equals(this.Name) && key.Age == this.Age;
        //}

        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(Name, Age);
        //}
    }

    //class DicComp : IEqualityComparer<KeyForDict>
    //{
    //    public bool Equals(KeyForDict? x, KeyForDict? y)
    //    {
    //        return x.Name.Equals(y.Name) && x.Age == y.Age;
    //    }

    //    public int GetHashCode([DisallowNull] KeyForDict obj)
    //    {
    //        return HashCode.Combine(obj.Name, obj.Age);
    //    }
    //}

    internal class Program
    {
        static void ProcessReports(IEnumerable<string> reports)
        {
            foreach (var item in reports)
            {
                Console.WriteLine(item);
            }


            var iterator = reports.GetEnumerator();
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
        }

        static void Main(string[] args)
        {
            var dic = new Dictionary<KeyForDict, string>(/*new DicComp()*/);
            //*****************************
            var sam1 = new KeyForDict
            {
                Name = "Sam",
                Age = 21
            };

            dic[sam1] = "hello";
            sam1.Age = 22;
            var val = dic[sam1];

            //*****************************
            var sam2 = new KeyForDict
            {
                Name = "Sam",
                Age = 21
            };
            var value = dic[sam2];

            //***************************************


            Pizza pizza = new ItalianPizza();

            pizza = new CheesePizzaDecorator(pizza, "parmezan");
            pizza = new MeatPizzaDecorator(pizza, "Chicken");

            pizza = new MeatPizzaDecorator(pizza, "Beef");

            pizza.Prepare();


            var some = new SomeClass();
            foreach (var item in some.GetInts())
            {
                Console.WriteLine(item);
            }

            var qu = new Lib.Queue<string>();
            qu.Enqueue("1");
            qu.Enqueue("2");
            qu.Enqueue("3");
            ProcessReports(qu);


            var reports = new DataStructers.Lib.List<string>();
            reports.Add("Oleg");
            reports.Add("Sam");
            reports.Add("Bill");

            ProcessReports(reports);

            var reports2 = new DataStructers.Lib.LinkedList<string>();
            reports2.Add("Hello");
            reports2.Add("Ok");

            ProcessReports(reports2);

            var rep3 = new ReportStorage();

            ProcessReports(rep3);




            //var filtered =
            //    LinqExtensions.Get(LinqExtensions.Filter(list, item => item.Contains('l')), 10);

            var filtered =
                qu
                    .Filter(item => item.Contains('l'))
                    .Get(10);

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //var iterator = list.GetEnumerator();

            //while(iterator.MoveNext())
            //{
            //    Console.WriteLine(iterator.Current);
            //}
            //iterator.Dispose();



            var logger = new FileLogger();
            var renerer = new ConsoleTestRenderer();

            ITestGroup[] tests = { new ListTests(), new LinkedListTests() };

            foreach (var testGroup in tests)
            {
                //testGroup.Attach((ITestGroupStartObserver)logger);

                //testGroup.Attach((ITestGroupStartObserver)renerer);
                //testGroup.AddTestStart(renerer.RenderHeader);
                //testGroup.OnBeforeTestGroupRun += logger.StartTestGroup;
                testGroup.OnAfterTestRun += logger.SaveTestResult;

                testGroup.OnBeforeTestGroupRun += renerer.RenderHeader;
                testGroup.OnAfterTestRun += renerer.ShowTestResult;

                testGroup.Run();

                testGroup.OnAfterTestRun -= renerer.ShowTestResult;
                testGroup.OnBeforeTestGroupRun -= renerer.RenderHeader;
                //testGroup.Detach((ITestGroupStartObserver)renerer);
                //testGroup.RemoveTestStart(renerer.RenderHeader);
            }

            //OldTests.Run();
        }
    }
}
