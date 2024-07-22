using DataStructers.Lib;
using DataStructers.Lib.Interfaces;
using System;
using DataStructers.Lib.Linq;

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

    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new DataStructers.Lib.List<string>();
            list.Add("Oleg");
            list.Add("Sam");
            list.Add("Bill");

            //var filtered =
            //    LinqExtensions.Get(LinqExtensions.Filter(list, item => item.Contains('l')), 10);

            var filtered =
                list
                    .Filter(item => item.Contains('l'))
                    .Get(10);

            foreach (var item in filtered)
            {
                Console.WriteLine(item);
            }

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
