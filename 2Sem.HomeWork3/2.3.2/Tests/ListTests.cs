using NUnit.Framework;

namespace _2._3._2
{
    public class ListTests
    {
        List list;

        [SetUp]
        public void Setup()
        {
            list = new List();
        }

        [Test]
        public void EmptyTest()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void AddTest()
        {
            list.Add("Hello");
            Assert.IsFalse(list.IsEmpty());
            list.Clear();
        }

        [Test]
        public void DeleteElementTest()
        {
            list.Add("Hello");
            list.Remove("Hello");
            Assert.IsTrue(list.IsEmpty());
            list.Clear();
        } 

        [Test]
        public void IsContainTest()
        {
            list.Add("Hello");
            Assert.IsTrue(list.IsContain("Hello"));
            list.Remove("Hello");
            Assert.IsFalse(list.IsContain("Hello"));
            list.Clear();
        }

        [Test]
        public void PopTest()
        {
            list.Add("Hello");
            list.Add("Goodbye");
            Assert.AreEqual("Hello", list.Pop());
            Assert.AreEqual("Goodbye", list.Pop());
            list.Clear();
        }

        [Test]
        public void ClearTest()
        {
            list.Add("Hello");
            Assert.IsFalse(list.IsEmpty());
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void GetSizeTest()
        {
            list.Add("Hello");
            list.Add("Goodbye");
            Assert.AreEqual(2, list.GetSize());
            list.Remove("Hello");
            Assert.AreEqual(1, list.GetSize());
            list.Remove("Goodbye");
            Assert.AreEqual(0, list.GetSize());

            list.Add("Hello");
            list.Add("Goodbye");
            Assert.AreEqual(2, list.GetSize());
            list.Clear();
            Assert.AreEqual(0, list.GetSize());
        }
    }
}
