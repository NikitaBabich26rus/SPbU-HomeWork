using NUnit.Framework;

namespace _2._4._2
{
    public class ListTests
    {
        private List list;

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
            list.Add(1, 1);
            Assert.IsTrue(list.IsContain(1));
        }

        [Test]
        public void DeleteElementTest()
        {
            list.Add(1, 1);
            list.Delete(1);
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void IsContainTest()
        {
            list.Add(1, 1);
            Assert.IsTrue(list.IsContain(1));
            list.Delete(1);
            Assert.IsFalse(list.IsContain(1));
        }

        [Test]
        public void DeleteElementFromEmptyListTest()
        {
            Assert.Throws<DeletingAnElementThatIsNotInTheListException>(() => list.Delete(5));
        }

        [Test]
        public void DeleteAnElementThatIsNotInTheListTest() 
        {
            list.Add(7, 1);
            Assert.IsFalse(list.IsContain(5));
            Assert.Throws<DeletingAnElementThatIsNotInTheListException>(() => list.Delete(5));
        }

        [Test]
        public void GetSizeTest()
        {
            list.Add(1, 1);
            list.Add(2, 2);
            Assert.AreEqual(2, list.GetSize());
            list.Delete(1);
            Assert.AreEqual(1, list.GetSize());
            list.Delete(1);
            Assert.AreEqual(0, list.GetSize());
        }
    }
}