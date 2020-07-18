using NUnit.Framework;
using System.Collections.Generic;

namespace test2._2
{
    public class IntBubbleSortTest
    {
        private List<int> list;

        /// <summary>
        /// Int comparer class.
        /// </summary>
        public class IntComparer : IComparer<int>
        {
            public int Compare(int element1, int element2)
            {
                return (element1 > element2) ? 1 : ((element1 < element2) ? -1 : 0);
            }
        }

        [SetUp]
        public void Setup()
        {
            list = new List<int>();
        }

        [Test]
        public void IntListSortingWithPositiveNumbersTest()
        {
            var answerList = new List<int>();
            answerList.Add(3);
            answerList.Add(4);
            answerList.Add(5);
            answerList.Add(6);
            answerList.Add(7);
            answerList.Add(8);
            answerList.Add(9);
            answerList.Add(10);
            list.Add(10);
            list.Add(9);
            list.Add(8);
            list.Add(7);
            list.Add(6);
            list.Add(5);
            list.Add(4);
            list.Add(3);
            var newlist = BubbleSort.Sort<int>(list, new IntComparer());
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(answerList[i], newlist[i]);
            }
        }

        [Test]
        public void IntListSortingWithAnyNumbersTest()
        {
            var answerList = new List<int>();
            answerList.Add(-15);
            answerList.Add(-13);
            answerList.Add(-8);
            answerList.Add(0);
            answerList.Add(0);
            answerList.Add(4);
            answerList.Add(10);
            answerList.Add(150);
            list.Add(10);
            list.Add(-13);
            list.Add(-8);
            list.Add(0);
            list.Add(0);
            list.Add(-15);
            list.Add(4);
            list.Add(150);
            var newlist = BubbleSort.Sort<int>(list, new IntComparer());
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(answerList[i], newlist[i]);
            }
        }
    }
}