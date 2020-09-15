using NUnit.Framework;
using System;

namespace HomeWork2
{
    public class LazySingleThreadedTests
    {
        private LazySingleThreaded<string> lazySingleThreaded;

        [SetUp]
        public void Setup()
        {
            lazySingleThreaded = LazyFactory<string>.CreateSingleThreadedLazy(() => "Hello world");
        }

        [Test]
        public void TestForCorrectSingleThreading()
        {
            for (int i = 0; i < 10000; i++)
            {
                Assert.AreEqual("Hello world", lazySingleThreaded.Get());
            }
        }

        [Test]
        public void NullFunctionTesting()
        {
            Assert.Throws<ArgumentNullException>(() => LazyFactory<int>.CreateSingleThreadedLazy(null));
        }
    }
}