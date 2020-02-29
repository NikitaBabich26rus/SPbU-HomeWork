using System;
using NUnit.Framework;
using System.Collections;

namespace _2._3._1
{
    public class StackTests 
    {
        private IStack listStack;
        private IStack arrayStack;

        [SetUp]
        public void Setup()
        {
            listStack = new ListStack();
            arrayStack = new ArrayStack();
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.IsTrue(listStack.IsEmpty());
            Assert.IsTrue(arrayStack.IsEmpty());
        }

        [Test]
        public void PopTest()
        {
            listStack.Push(-21);
            arrayStack.Push(-21);
            Assert.AreEqual(-21, arrayStack.Pop().Item1);
            Assert.AreEqual(-21, listStack.Pop().Item1);
        }

        [Test]
        public void PushTest()
        {
            listStack.Push(99999999);
            arrayStack.Push(99999999);
            Assert.IsFalse(listStack.IsEmpty());
            Assert.IsFalse(listStack.IsEmpty());
        }

        [Test]
        public void PopFromEmptyStackTest()
        {
            arrayStack.Pop();
        }

        [Test]
        public void TwoElementsPopTest()
        {
            listStack.Push(1);
            listStack.Push(2);
            Assert.AreEqual(2, listStack.Pop().Item1);
            Assert.AreEqual(1, listStack.Pop().Item1);

            arrayStack.Push(1);
            arrayStack.Push(2);
            Assert.AreEqual(2, arrayStack.Pop().Item1);
            Assert.AreEqual(1, arrayStack.Pop().Item1);
        }

        [Test]
        public void ManyElementsPushAndPopTest()
        {
            for (int i = 0; i <= 1000000; i++)
            {
                listStack.Push(i);
                arrayStack.Push(i);
            }

            for (int i = 1000000; i >= 0; i--)
            {
                Assert.AreEqual(i, listStack.Pop().Item1);
                Assert.AreEqual(i, arrayStack.Pop().Item1);
            }
        }
        
        [Test]
        public void ClearTest()
        {
            listStack.Clear();
            arrayStack.Clear();

            Assert.IsTrue(listStack.IsEmpty());
            Assert.IsTrue(arrayStack.IsEmpty());

        }
    }
}