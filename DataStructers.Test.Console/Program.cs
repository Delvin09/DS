using System;

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
        public void SaveTestResult(object sender, EventArgs eventArgsf)
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
