using NUnit.Framework;

namespace _2._4._1
{
    public class MultiplicationTests
    {
        private Multiplication multiplication;
        private Number leftChild;
        private Number rightChild;

        [SetUp]
        public void Setup()
        {
            multiplication = new Multiplication();
            leftChild = new Number(1);
            rightChild = new Number(1);
            multiplication.LeftChild = leftChild;
            multiplication.RightChild = rightChild;
        }

        [Test]
        public void MultiplicationOfLargeNumbersTest()
        {
            leftChild.Value = 2311;
            rightChild.Value = 9999;
            Assert.AreEqual(23107689, multiplication.Counting());
        }

        [Test]
        public void MultiplicationWithRemainderTest()
        {
            leftChild.Value = 3.3;
            rightChild.Value = 2.23;
            Assert.AreEqual(7.359, multiplication.Counting());
        }

        [Test]
        public void DivisionByZeroTest()
        {
            leftChild.Value = -1311.31;
            rightChild.Value = 0;
            Assert.AreEqual(0, multiplication.Counting());
        }
    }
}