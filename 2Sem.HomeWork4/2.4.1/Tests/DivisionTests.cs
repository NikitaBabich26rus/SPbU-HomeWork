using NUnit.Framework;
using System;

namespace _2._4._1
{
    public class DivisionTests
    {
        private Division division;
        private Number leftChild;
        private Number rightChild;

        [SetUp]
        public void Setup()
        {
            division = new Division();
            leftChild = new Number(1);
            rightChild = new Number(1);
            division.LeftChild = leftChild;
            division.RightChild = rightChild;
        }

        [Test]
        public void DivisionOfLargeNumbersTest()
        {
            leftChild.Value = 100000000;
            rightChild.Value = 2;
            Assert.AreEqual(50000000, division.Counting());
        }

        [Test]
        public void DivisionWithRemainderTest()
        {
            leftChild.Value = 3;
            rightChild.Value = 2;
            Assert.AreEqual(1.5, division.Counting());
        }

        [Test]
        public void DivisionByZeroTest()
        {
            leftChild.Value = 1311.31;
            rightChild.Value = 0;
            Assert.Throws<DivideByZeroException>(() => division.Counting());
        }
    }
}