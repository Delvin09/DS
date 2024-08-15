using TestFrameWork.Abstractions;
using CustomLinkedList = DataStructers.Lib.LinkedList<object>;

namespace DataStructers.Test
{
    [TestGroup(Title = "LinkedList")]
    class LinkedListTests
    {
        [Test]
        private void TestAddElements()
        {
            var linkedList = new CustomLinkedList();

            linkedList.Add(10);
            linkedList.Add(20);
            linkedList.Add(30);

            Assert.AreEquals(linkedList.Count, 3);
            Assert.AreEquals((int)linkedList.First, 10);
            Assert.AreEquals((int)linkedList.Last, 30);
        }
    }
}
