using NUnit.Framework;
using Test4;

namespace Tests
{
    public class QSortTest
    {
        QSort qSort;

        [SetUp]
        public void Setup()
        {
            qSort = new QSort();
        }

        [Test]
        public void SingleThreadedEqualMultiThreadedTest()
        {
            var array = new int[10000];
            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[i] = i;
            }
            var result1 = qSort.SingleThreadedQuickSort(array);
            var result2 = qSort.MultiThreadedQuickSort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(result1[i], result2[i]);
            }
        }
    }
}