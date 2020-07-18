using NUnit.Framework;
using System.Collections.Generic;

namespace test2._2
{
    public class StringBubbleSortTest
    {
        private List<string> list;

        /// <summary>
        /// String comparer class.
        /// </summary>
        public class StringComparer : IComparer<string>
        {
            public int Compare(string value1, string value2)
            {
                return string.Compare(value1, value2);
            }
        }

        [SetUp]
        public void Setup()
        {
            list = new List<string>();
        }

        [Test]
        public void StringListSortingWithNamesTest()
        {
            var answerList = new List<string>();
            answerList.Add("John");
            answerList.Add("Kolya");
            answerList.Add("Nastya");
            answerList.Add("Nikita");
            answerList.Add("Peter");
            answerList.Add("Sam");
            answerList.Add("Sasha");
            answerList.Add("Vasya");
            list.Add("Kolya");
            list.Add("Vasya");
            list.Add("Nikita");
            list.Add("Peter");
            list.Add("John");
            list.Add("Sasha");
            list.Add("Nastya");
            list.Add("Sam");
            var newlist = BubbleSort.Sort<string>(list, new StringComparer());
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(answerList[i], newlist[i]);
            }
        }

        [Test]
        public void StringListSortingWithRandomStringsTest()
        {
            var answerList = new List<string>();
            answerList.Add("abcd");
            answerList.Add("Evan");
            answerList.Add("ffgd");
            answerList.Add("ggggg");
            answerList.Add("hfhfh");
            answerList.Add("klmn");
            answerList.Add("qwe");
            answerList.Add("w");
            list.Add("w");
            list.Add("hfhfh");
            list.Add("ggggg");
            list.Add("Evan");
            list.Add("abcd");
            list.Add("ffgd");
            list.Add("qwe");
            list.Add("klmn");
            var newlist = BubbleSort.Sort<string>(list, new StringComparer());
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(answerList[i], newlist[i]);
            }
        }
    }
}