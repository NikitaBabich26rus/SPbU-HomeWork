using NUnit.Framework;
using System;

namespace HomeWork2
{
    public class LazySingleThreadedTests
    {
        private LazySingleThreaded<int> lazySingleThreaded;
        private int numberOfFunctionStarts;

        [SetUp]
        public void Setup()
        {
            lazySingleThreaded = LazyFactory<int>.CreateSingleThreadedLazy(() =>
            {
                numberOfFunctionStarts++;
                return 5;
            });
        }

        [Test]
        public void TestForCorrectSingleThreading()
        {
            for (int i = 0; i < 10000; i++)
            {
                Assert.AreEqual(5, lazySingleThreaded.Get());
                Assert.AreEqual(1, numberOfFunctionStarts);
            }
        }

        [Test]
        public void NullFunctionTesting()
        {
            Assert.Throws<ArgumentNullException>(() => LazyFactory<int>.CreateSingleThreadedLazy(null));
        }
    }
}