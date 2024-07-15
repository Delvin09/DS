using System;

namespace DataStructers.Test
{
    class MyClass
    {
        private bool Bar() { return false; }

        public Func<int, int> Run()
        {
            return Foo;
        }

        private void Process(Func<int, string, int> whenDone, Func<int, string, int> whenError)
        {
            //....
            var result = whenDone(10, "Callback call");
            //....
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

    internal class Program
    {
        static void Main(string[] args)
        {
            ITests[] tests = { new ListTests(), new LinkedListTests() };
            foreach (var testGroup in tests)
            {
                testGroup.Run();

                var runMethod = testGroup.Run;
            }

            //OldTests.Run();

            var myobj = new MyClass();

            Func<int, int> callback = M2;
            callback += M2;
            callback += M2;
            callback += myobj.Run();
            callback += M2;
            callback += M2;
            callback += myobj.Run();

            callback -= myobj.Run();

            var result = callback(11);
            Console.WriteLine(result);

            Func<int, bool> someDelegate = item =>
            {
                Console.WriteLine("100");
                return item % 100 > 90;
            };

            someDelegate += item =>
            {
                Console.WriteLine("50");
                return item % 50 > 90;
            };

            someDelegate -= item =>
            {
                Console.WriteLine("50");
                return item % 50 > 90;
            };

            someDelegate(1000);
        }

        static int M2(int y)
        {
            Console.WriteLine($"{y} <> ");
            return 1;
        }
    }
}
