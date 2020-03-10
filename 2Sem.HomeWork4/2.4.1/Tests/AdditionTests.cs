using NUnit.Framework;

namespace _2._4._1
{
    public class AdditionTests
    {
        private Addition addition;
        private Number leftChild;
        private Number rightChild;

        [SetUp]
        public void Setup()
        {
            addition = new Addition();
            leftChild = new Number(1);
            rightChild = new Number(1);
            addition.LeftChild = leftChild;
            addition.RightChild = rightChild;
        }

        [Test]
        public void AdditionOfLargeNumbersTest()
        {
            leftChild.value = 100000000;
            rightChild.value = 99999999;
            Assert.AreEqual(199999999, addition.Counting());
        }

        [Test]
        public void AdditionWithRemainderTest()
        {
            leftChild.value = 3.3;
            rightChild.value = 4;
            Assert.AreEqual(7.3, addition.Counting());
        }

        //[Test]
        //public void AdditionByZeroTest()
        //{
        //    leftChild.value = 1311.31;
        //    rightChild.value = 0;
        //    Assert.AreEqual(1311.31, addition.Counting());
        //}
    }
}