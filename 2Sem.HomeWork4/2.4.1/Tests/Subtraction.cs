using NUnit.Framework;

namespace _2._4._1
{
    public class SubtractionTests
    {
        private Subtraction subtraction;
        private Number leftChild;
        private Number rightChild;

        [SetUp]
        public void Setup()
        {
            subtraction = new Subtraction();
            leftChild = new Number(1);
            rightChild = new Number(1);
            subtraction.LeftChild = leftChild;
            subtraction.RightChild = rightChild;
        }

        [Test]
        public void SubstractionOfLargeNumbersTest()
        {
            leftChild.value = 99;
            rightChild.value = 999999999;
            Assert.AreEqual(-999999900, subtraction.Counting());
        }

        [Test]
        public void SubstractionWithRemainderTest()
        {
            leftChild.value = 5.12;
            rightChild.value = 2.04;
            Assert.AreEqual(3.08, subtraction.Counting());
        }

        [Test]
        public void SubstractionByZeroTest()
        {
            leftChild.value = -1311.31;
            rightChild.value = 0;
            Assert.AreEqual(-1311.31, subtraction.Counting());
        }
    }
}