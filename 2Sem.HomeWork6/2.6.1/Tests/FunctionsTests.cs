using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2._6._1
{
    public class Tests
    {
        [Test]
        public void MapWithAdditionTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var answerList = new List<int>() { 4, 5, 6, 7, 8 };
            list = Functions.Map(list, x => x + 3);
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(list[i], answerList[i]);
            }
        }

        [Test]
        public void MapWithMultiplicationTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var answerList = new List<int>() { 5, 10, 15, 20, 25 };
            list = Functions.Map(list, x => x * 5);
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(list[i], answerList[i]);
            }
        }

        [Test]
        public void MapWithExponentiationTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var answerList = new List<int>() { 1, 4, 9, 16, 25 };
            list = Functions.Map(list, x => x * x);
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(list[i], answerList[i]);
            }
        }

        [Test]
        public void MapWithDivisionTest()
        {
            var list = new List<int>() { 2, 4, 6, 8, 10 };
            var answerList = new List<int>() { 1, 2, 3, 4, 5 };
            list = Functions.Map(list, x => x / 2);
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(list[i], answerList[i]);
            }
        }

        [Test]
        public void FilterWithParityCheckTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var answerList = new List<int>() { 2, 4 };
            list = Functions.Filter(list, x => x % 2 == 0);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(list[i], answerList[i]);
            }
        }

        [Test]
        public void FilterWithEmptyListTest()
        {
            var list = new List<int>();
            list = Functions.Filter(list, x => x % 2 == 0);
        }

        [Test]
        public void FilterWithManyElementsTest()
        {
            var list = new List<int>();
            for (int i = 0; i <= 10000; i++)
            {
                list.Add(i);
            }
            list = Functions.Filter(list, x => x % 2 == 0);
            int currentValue = 0;
            foreach (var listElement in list)
            {
                Assert.AreEqual(listElement, currentValue * 2);
                currentValue++;
            }
        }

        [Test]
        public void NoListElementWillPassTheFilterTest()
        {
            var list = new List<int>();
            for (int i = 0; i <= 10000; i++)
            {
                list.Add(i);
            }
            list = Functions.Filter(list, x => x == -23321);
            Assert.IsTrue(list.Count == 0);
        }

        [Test]
        public void FoldWithAdditionTest()
        {
            var list = new List<int>() {1, 2, 3, 4, 5 };
            int result = Functions.Fold(list, 1, (x, y) => x + y);
            Assert.AreEqual(result, 16);
        }

        [Test]
        public void FoldWithManyListElementsTest()
        {
            var list = new List<int>();
            for (int i = 0; i <= 1000; i++)
            {
                list.Add(i);
            }
            int result = Functions.Fold(list, 0, (x, y) => x + y);
            Assert.AreEqual(result, 500500);
        }

        [Test]
        public void FoldWithHugeCurrentValueTest()
        {
            var list = new List<int>() { 1, 2, 3};
            int result = Functions.Fold(list, 1000000, (x, y) => x * y);
            Assert.AreEqual(result, 6000000);
        }
    }

}