using TestFrameWork.Abstractions;
using CustomList = DataStructers.Lib.List<object>;

namespace DataStructers.Test
{
    [TestGroup(Title = "List")]
    class ListTests
    {
        [Test]
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

            Assert.IsTrue(isSuccess);
        }

        [Test]
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

            Assert.IsTrue(hasElements);
        }

        [Test]
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

            Assert.IsTrue(isSuccess);
        }

        [Test]
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

            Assert.IsTrue(isSuccess);
        }

        [Test]
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

            Assert.IsTrue(isSuccess);
        }

        [Test]
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
            Assert.IsTrue(isSuccess);
        }

        [Test]
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
            Assert.IsTrue(isSuccess);
        }

        [Test]
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
            Assert.IsTrue(isSuccess);
        }

        [Test]
        private void TestListClear()
        {
            CustomList list = new CustomList();
            list.Add(10);
            list.Add("10");
            list.Add(null);

            var isSuccess = list.Count == 3;

            list.Clear();
            isSuccess &= list.Count == 0;

            Assert.IsTrue(isSuccess);
        }
    }
}
