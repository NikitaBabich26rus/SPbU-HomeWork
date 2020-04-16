using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace _2._3._1
{
    public class StackTests 
    {
        [TestCaseSource(nameof(Stacks))]
        public void StackShouldNotEmptyAfterPush(IStack stack)
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestCaseSource(nameof(Stacks))]
        public void IsEmptyTest(IStack stack)
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestCaseSource(nameof(Stacks))]
        public void PopTest(IStack stack)
        {
            stack.Push(-21);
            Assert.AreEqual(-21, stack.Pop().Item1);
        }

        [TestCaseSource(nameof(Stacks))]
        public void PushTest(IStack stack)
        {
            stack.Push(99999999);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestCaseSource(nameof(Stacks))]
        public void PopFromEmptyStackTest(IStack stack)
        {
            stack.Pop();
        }

        [TestCaseSource(nameof(Stacks))]
        public void TwoElementsPopTest(IStack stack)
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop().Item1);
            Assert.AreEqual(1, stack.Pop().Item1);
        }

        [TestCaseSource(nameof(Stacks))]
        public void ManyElementsPushAndPopTest(IStack stack)
        {
            for (int i = 0; i <= 1000000; i++)
            {
                stack.Push(i);
            }

            for (int i = 1000000; i >= 0; i--)
            {
                Assert.AreEqual(i, stack.Pop().Item1);
            }
        }
        
        [TestCaseSource(nameof(Stacks))]
        public void ClearTest(IStack stack)
        {
            stack.Clear();
            Assert.IsTrue(stack.IsEmpty());
        }

        private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
            new TestCaseData(new ArrayStack()),
            new TestCaseData(new ListStack()),
        };

    }
}