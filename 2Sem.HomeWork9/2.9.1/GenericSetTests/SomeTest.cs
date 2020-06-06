using NUnit.Framework;

namespace _2._9._1
{
    public class Tests
    {
        private GenericSet<int> set;

        [SetUp]
        public void Setup()
        {
            set = new GenericSet<int>();
        }

        [Test]
        public void SomeTest()
        {
            Assert.AreEqual(0, set.Count);
            set.Add(1);
            set.Add(2);
            set.Add(3);
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(2));
            Assert.IsTrue(set.Contains(3));
            Assert.AreEqual(3, set.Count);
            set.Remove(3);
            set.Remove(2);
            set.Remove(5);
            Assert.AreEqual(1, set.Count);
            Assert.IsTrue(set.Contains(1));
            set.Remove(1);
            Assert.AreEqual(0, set.Count);
            Assert.IsFalse(set.Contains(1));
            Assert.IsFalse(set.Contains(2));
            Assert.IsFalse(set.Contains(3));
        }
    }
}