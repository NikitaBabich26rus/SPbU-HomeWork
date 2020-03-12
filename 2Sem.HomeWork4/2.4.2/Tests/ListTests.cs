using NUnit.Framework;

namespace _2._4._2
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
            list.Add(1);
            Assert.IsFalse(list.IsEmpty());
            list.Clear();
        }

        [Test]
        public void DeleteElementTest()
        {
            list.Add(1);
            list.Delete(1);
            Assert.IsTrue(list.IsEmpty());
            list.Clear();
        }

        [Test]
        public void IsContainTest()
        {
            list.Add(1);
            Assert.IsTrue(list.IsContain(1));
            list.Delete(1);
            Assert.IsFalse(list.IsContain(1));
            list.Clear();
        }

        [Test]
        public void ClearTest()
        {
            list.Add(1);
            Assert.IsFalse(list.IsEmpty());
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void DeleteElementFromEmptyListTest()
        {
            list.Clear();
            Assert.Throws <DeletingAnElementThatIsNotInTheListException>(() => list.Delete(5));
        }

        [Test]
        public void DeleteAnElementThatIsNotInTheListTest() 
        {
            list.Add(7);
            Assert.IsFalse(list.IsContain(5));
            Assert.Throws<DeletingAnElementThatIsNotInTheListException>(() => list.Delete(5));
            list.Clear();
        }

        [Test]
        public void GetSizeTest()
        {
            list.Add(1);
            list.Add(2);
            Assert.AreEqual(2, list.GetSize());
            list.Delete(1);
            Assert.AreEqual(1, list.GetSize());
            list.Delete(2);
            Assert.AreEqual(0, list.GetSize());

            list.Add(1);
            list.Add(2);
            Assert.AreEqual(2, list.GetSize());
            list.Clear();
            Assert.AreEqual(0, list.GetSize());
        }
    }
}