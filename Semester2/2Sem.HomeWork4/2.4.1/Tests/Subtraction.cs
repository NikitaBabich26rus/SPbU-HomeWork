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
            leftChild.Value = 99;
            rightChild.Value = 999999999;
            Assert.AreEqual(-999999900, subtraction.Counting());
        }

        [Test]
        public void SubstractionWithRemainderTest()
        {
            leftChild.Value = 5.12;
            rightChild.Value = 2.04;
            Assert.AreEqual(3.08, subtraction.Counting());
        }

        [Test]
        public void SubstractionByZeroTest()
        {
            leftChild.Value = -1311.31;
            rightChild.Value = 0;
            Assert.AreEqual(-1311.31, subtraction.Counting());
        }
    }
}