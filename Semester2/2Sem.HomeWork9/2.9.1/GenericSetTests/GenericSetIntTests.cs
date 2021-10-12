using NUnit.Framework;

namespace _2._9._1
{
    public class Tests
    {
        public class GenericSetIntTests
        {
            private GenericSet<int> set;

            [SetUp]
            public void Setup()
            {
                set = new GenericSet<int>();
            }

            [Test]
            public void AddTest()
            {
                set.Add(3);
                Assert.AreEqual(1, set.Count);
            }

            [Test]
            public void AddingAnItemThatIsAlreadyContainedInSetTest()
            {
                set.Add(-5);
                Assert.AreEqual(1, set.Count);
                Assert.IsFalse(set.Add(-5));
                Assert.AreEqual(1, set.Count);
            }

            [Test]
            public void IsReadOnlyTest()
            {
                Assert.IsFalse(set.IsReadOnly);
            }

            [Test]
            public void ClearTest()
            {
                set.Add(1);
                set.Add(2);
                set.Add(3);
                set.Add(4);
                Assert.AreEqual(4, set.Count);
                set.Clear();
                Assert.AreEqual(0, set.Count);
            }

            [Test]
            public void ContainsTest()
            {
                set.Add(1);
                set.Add(2);
                set.Add(3);
                Assert.IsTrue(set.Contains(1));
                Assert.IsTrue(set.Contains(2));
                Assert.IsTrue(set.Contains(3));
                Assert.IsFalse(set.Contains(3121321));
                Assert.IsFalse(set.Contains(131221));
            }

            [Test]
            public void RemoveTest()
            {
                set.Add(10);
                set.Add(-8);
                set.Add(13);
                set.Add(1);
                set.Add(-13);
                set.Add(22);
                Assert.AreEqual(6, set.Count);
                Assert.IsTrue(set.Contains(1));
                set.Remove(1);
                Assert.AreEqual(5, set.Count);
                Assert.IsFalse(set.Contains(1));
                Assert.IsTrue(set.Contains(-13));
            }

            [Test]
            public void CopyToTest()
            {
                var array = new int[5];
                set.Add(1);
                set.Add(2);
                set.Add(3);
                set.Add(4);
                set.Add(5);
                set.CopyTo(array, 0);
                Assert.AreEqual(1, array[0]);
                Assert.AreEqual(2, array[1]);
                Assert.AreEqual(3, array[2]);
                Assert.AreEqual(4, array[3]);
                Assert.AreEqual(5, array[4]);
            }

            [Test]
            public void ExceptWithTest()
            {
                var someSet = new GenericSet<int>();
                set.Add(1);
                set.Add(2);
                set.Add(3);
                set.Add(4);
                set.Add(5);
                someSet.Add(1);
                someSet.Add(2);
                someSet.Add(3);
                someSet.Add(12);
                someSet.ExceptWith(set);
                Assert.IsFalse(someSet.Contains(1));
                Assert.IsFalse(someSet.Contains(2));
                Assert.IsFalse(someSet.Contains(3));
                Assert.IsTrue(someSet.Contains(12));
                Assert.AreEqual(1, someSet.Count);
            }

            [Test]
            public void IntersectWithTest()
            {
                var someSet = new GenericSet<int>();
                set.Add(1);
                set.Add(2);
                set.Add(3);
                set.Add(4);
                set.Add(5);
                someSet.Add(1);
                someSet.Add(2);
                someSet.Add(3);
                someSet.Add(6);
                someSet.Add(7);
                someSet.IntersectWith(set);
                Assert.IsFalse(someSet.Contains(6));
                Assert.IsFalse(someSet.Contains(7));
                Assert.IsTrue(someSet.Contains(1));
                Assert.IsTrue(someSet.Contains(2));
                Assert.IsTrue(someSet.Contains(3));
                Assert.AreEqual(3, someSet.Count);
            }

            [Test]
            public void IsProperSubsetOfTest()
            {
                var someSet = new GenericSet<int>();
                set.Add(1);
                set.Add(2);
                set.Add(3);
                set.Add(4);
                someSet.Add(4);
                someSet.Add(3);
                someSet.Add(2);
                someSet.Add(1);
                Assert.IsFalse(someSet.IsProperSubsetOf(set));
            }

            [Test]
            public void IsProperSupersetOfTest()
            {
                var someSet = new GenericSet<int>();
                set.Add(1);
                set.Add(2);
                set.Add(3);
                someSet.Add(3);
                someSet.Add(2);
                someSet.Add(4433);
                someSet.Add(-132);
                someSet.Add(1312);
                someSet.Add(1);
                Assert.IsTrue(someSet.IsProperSupersetOf(set));
            }

            [Test]
            public void IsSubsetOfTest()
            {
                var someSet = new GenericSet<int>();
                set.Add(1);
                set.Add(2);
                set.Add(3);
                someSet.Add(3);
                someSet.Add(2);
                someSet.Add(1);
                Assert.IsTrue(someSet.IsSubsetOf(set));
            }

            [Test]
            public void IsSupersetOfTest()
            {
                var someSet = new GenericSet<int>();
                set.Add(1);
                set.Add(2);
                set.Add(3);
                someSet.Add(1);
                someSet.Add(2);
                someSet.Add(3);
                someSet.Add(31);
                someSet.Add(31213);
                someSet.Add(1122);
                Assert.IsTrue(someSet.IsSupersetOf(set));
            }

            [Test]
            public void OverlapsTest()
            {
                var someSet = new GenericSet<int>();
                set.Add(1);
                set.Add(2);
                set.Add(3);
                someSet.Add(4);
                someSet.Add(4);
                someSet.Add(5);
                someSet.Add(6);
                someSet.Add(7);
                someSet.Add(8);
                Assert.IsFalse(someSet.Overlaps(set));
            }

            [Test]
            public void SetEqualsTest()
            {
                var someSet = new GenericSet<int>();
                set.Add(1);
                set.Add(2);
                set.Add(3);
                set.Add(4);
                someSet.Add(4);
                someSet.Add(2);
                someSet.Add(3);
                someSet.Add(1);
                Assert.IsTrue(someSet.SetEquals(set));
            }

            [Test]
            public void SymmetricExceptWithTest()
            {
                var someSet = new GenericSet<int>();
                set.Add(1);
                set.Add(2);
                set.Add(0);
                set.Add(4);
                someSet.Add(5);
                someSet.Add(2);
                someSet.Add(0);
                someSet.Add(-1);
                someSet.Add(-4);
                someSet.SymmetricExceptWith(set);
                Assert.IsFalse(someSet.Contains(2));
                Assert.IsFalse(someSet.Contains(0));
                Assert.IsTrue(someSet.Contains(1));
                Assert.IsTrue(someSet.Contains(-1));
                Assert.IsTrue(someSet.Contains(4));
                Assert.IsTrue(someSet.Contains(-4));
                Assert.IsTrue(someSet.Contains(5));
                Assert.AreEqual(5, someSet.Count);
            }

            [Test]
            public void UnionWithTest()
            {
                var someSet = new GenericSet<int>();
                set.Add(1);
                set.Add(2);
                set.Add(0);
                someSet.Add(0);
                someSet.Add(-1);
                someSet.Add(-4);
                someSet.UnionWith(set);
                Assert.IsTrue(someSet.Contains(-4));
                Assert.IsTrue(someSet.Contains(2));
                Assert.IsTrue(someSet.Contains(0));
                Assert.IsTrue(someSet.Contains(-4));
                Assert.IsTrue(someSet.Contains(-1));
                Assert.AreEqual(5, someSet.Count);
            }
        }
    }
}