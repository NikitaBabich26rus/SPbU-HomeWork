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
            leftChild.value = 2311;
            rightChild.value = 9999;
            Assert.AreEqual(23107689, multiplication.Counting());
        }

        [Test]
        public void MultiplicationWithRemainderTest()
        {
            leftChild.value = 3.3;
            rightChild.value = 2.23;
            Assert.AreEqual(7.359, multiplication.Counting());
        }

        [Test]
        public void DivisionByZeroTest()
        {
            leftChild.value = -1311.31;
            rightChild.value = 0;
            Assert.AreEqual(0, multiplication.Counting());
        }
    }
}