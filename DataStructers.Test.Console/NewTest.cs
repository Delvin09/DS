using DataStructers.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomList = DataStructers.Lib.List<object>;
using CustomLinkedList = DataStructers.Lib.LinkedList<object>;
using System.Xml.Linq;
using System.ComponentModel;

namespace DataStructers.Test
{
    public class ConsoleTestRenderer
    {
        private int _identCount;

        protected int IdentCount
        {
            get { return _identCount; }
            set
            {
                if (_identCount == value) return;
                if (value < 0 || value > 6) throw new ArgumentException();
                _identCount = value;
            }
        }

        public void RenderHeader(object sender, string testGroup)
        {
            System.Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.ForegroundColor = ConsoleColor.Blue;

            System.Console.Write(testGroup);
            System.Console.ForegroundColor = ConsoleColor.Black;
            System.Console.Write(" tests run:");
            System.Console.WriteLine();

            System.Console.ResetColor();
            IdentCount++;
        }

        public void ShowTestResult(object sender, AfterTestRunEventArgs args)
        {
            System.Console.ResetColor();

            for (int num = 1; num <= _identCount; num++) System.Console.Write("  ");
            System.Console.Write($"{args.TestName}: ");

            string resultMsg;
            if (args.IsSuccess)
            {
                System.Console.BackgroundColor = ConsoleColor.Green;
                System.Console.ForegroundColor = ConsoleColor.White;
                resultMsg = "SUCCESS!";
            }
            else
            {
                System.Console.BackgroundColor = ConsoleColor.Red;
                System.Console.ForegroundColor = ConsoleColor.White;
                resultMsg = "FAILED!";
            }

            if (System.Console.CursorLeft < 35) System.Console.SetCursorPosition(40, System.Console.CursorTop);

            System.Console.Write(resultMsg);
            System.Console.ResetColor();
            System.Console.WriteLine(" ");
        }
    }

    public class AfterTestRunEventArgs : EventArgs
    {
        public string TestName { get; init; }

        public bool IsSuccess { get; init; }
    }

    public interface ITestGroup
    {
        string Name { get; }

        void Run();

        event EventHandler<string>? OnBeforeTestGroupRun;
        event EventHandler<string>? OnAfterTestGroupRun;

        event EventHandler<AfterTestRunEventArgs>? OnAfterTestRun;
    }

    abstract class TestGroup : ITestGroup
    {
        public abstract string Name { get; }

        public void Run()
        {
            if (OnBeforeTestGroupRun != null)
            {
                OnBeforeTestGroupRun(this, Name);
            }

            var tests = GetTests();
            foreach (var test in tests)
            {
                test();
            }

            OnAfterTestGroupRun?.Invoke(this, Name);
        }

        protected abstract System.Collections.Generic.List<Action> GetTests();

        protected void SendTestResult(string testName, bool isSuccess)
        {
            OnAfterTestRun?.Invoke(
                sender: this,
                e: new AfterTestRunEventArgs
                {
                    TestName = testName,
                    IsSuccess = isSuccess
                });
        }

        public event EventHandler<string>? OnBeforeTestGroupRun;
        public event EventHandler<string>? OnAfterTestGroupRun;

        public event EventHandler<AfterTestRunEventArgs>? OnAfterTestRun;
    }

    class LinkedListTests : TestGroup
    {
        public override string Name => "DataStructers.Lib.LinkedList";

        protected override System.Collections.Generic.List<Action> GetTests()
        {
            return new System.Collections.Generic.List<Action> {
                TestAddElements
            };
        }

        private void TestAddElements()
        {
            var linkedList = new CustomLinkedList();

            linkedList.Add(10);
            linkedList.Add(20);
            linkedList.Add(30);

            var isSuccess = linkedList.Count == 3
                && (int)linkedList.First == 10
                && (int)linkedList.Last == 30;

            SendTestResult(nameof(TestAddElements), isSuccess);
        }
    }

    class ListTests : TestGroup
    {
        public override string Name => "DataStructers.Lib.List";

        protected override System.Collections.Generic.List<Action> GetTests()
        {
            return new System.Collections.Generic.List<Action>() {
                TestAddElements,
                TestListContains,
                TestListInsert,
                TestListReverse,
                TestListRemove,
                TestListRemoveAt,
                TestListIndexOf,
                TestListToArray,
                TestListClear,
            };
        }

        private void TestAddElements()
        {
            CustomList list = new CustomList();
            list.Add(10);
            list.Add("10");
            list.Add('c');
            list.Add(10.2);
            list.Add("end");

            var isSuccess = list.Count == 5
                && list[0] is int && (int)list[0]! == 10
                && list[1] is string && (string)list[1]! == "10"
                && list[2] is char && (char)list[2]! == 'c'
                && list[3] is double && (double)list[3]! == 10.2
                && list[4] is string && (string)list[4]! == "end";

            SendTestResult(nameof(TestAddElements), isSuccess);
        }

        private void TestListContains()
        {
            CustomList list = new CustomList();
            list.Add(10);
            list.Add("10");
            list.Add('c');
            list.Add(10.2);
            list.Add("end");

            var hasElements = list.Contains(10)
                && list.Contains("10")
                && !list.Contains(null);

            SendTestResult(nameof(TestListContains), hasElements);
        }

        private void TestListIndexOf()
        {
            CustomList list = new CustomList();
            list.Add(10);
            list.Add("10");
            list.Add('c');
            list.Add(10.2);
            list.Add("end");

            var isSuccess = list.IndexOf(10) == 0
                && list.IndexOf("end") == 4
                && list.IndexOf('c') == 2
                && list.IndexOf(null) < 0;

            SendTestResult(nameof(TestListIndexOf), isSuccess);
        }

        private void TestListInsert()
        {
            CustomList list = new CustomList();
            list.Insert(0, "1");
            list.Insert(0, "2");
            list.Insert(1, "3");

            var isSuccess = list.Count == 3
                && (string)list[0]! == "2"
                && (string)list[1]! == "3"
                && (string)list[2]! == "1";

            SendTestResult(nameof(TestListInsert), isSuccess);
        }

        private void TestListReverse()
        {
            CustomList list = new CustomList();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Reverse();

            var isSuccess = list.Count == 3
                && (int)list[0]! == 3
                && (int)list[1]! == 2
                && (int)list[2]! == 1;

            SendTestResult(nameof(TestListReverse), isSuccess);
        }

        private void TestListRemove()
        {
            CustomList list = new CustomList();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Remove(2);
            var isSuccess = list.Count == 2
                && (int)list[0]! == 1
                && (int)list[1]! == 3;

            if (!isSuccess) goto exit;
            list.Remove(1);
            isSuccess &= list.Count == 1
                && (int)list[0]! == 3;

            if (!isSuccess) goto exit;
            list.Remove(3);
            isSuccess &= list.Count == 0;

        exit:
            SendTestResult(nameof(TestListRemove), isSuccess);
        }

        private void TestListRemoveAt()
        {
            CustomList list = new CustomList();
            list.Add('1');
            list.Add('2');
            list.Add('3');

            list.RemoveAt(1);
            var isSuccess = list.Count == 2
                && (char)list[0]! == '1'
                && (char)list[1]! == '3';

            if (!isSuccess) goto exit;
            list.RemoveAt(1);
            isSuccess &= list.Count == 1
                && (char)list[0]! == '3';

            if (!isSuccess) goto exit;
            list.RemoveAt(3);
            isSuccess &= list.Count == 0;

        exit:
            SendTestResult(nameof(TestListRemove), isSuccess);
        }

        private void TestListToArray()
        {
            CustomList list = new CustomList();
            list.Add(10);
            list.Add("10");
            list.Add(null);

            var arr = list.ToArray();
            var isSuccess = arr.Length == 3
                && (int)arr[0]! == 10
                && (string)arr[1]! == "10"
                && arr[2] == null;

            if (!isSuccess) goto exit;
            arr[0] = 11;
            arr[1] = "11";
            isSuccess &= !arr[0]!.Equals(list[0])
                && !arr[1]!.Equals(list[1]);

        exit:
            SendTestResult(nameof(TestListToArray), isSuccess);
        }

        private void TestListClear()
        {
            CustomList list = new CustomList();
            list.Add(10);
            list.Add("10");
            list.Add(null);

            var isSuccess = list.Count == 3;

            list.Clear();
            isSuccess &= list.Count == 0;

            SendTestResult(nameof(TestListToArray), isSuccess);
        }
    }
}
