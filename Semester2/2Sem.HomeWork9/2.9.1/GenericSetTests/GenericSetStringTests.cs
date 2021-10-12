using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace _2._9._1
{
    public class GenericSetStringTests
    {
        private GenericSet<string> set;

        [SetUp]
        public void Setup()
        {
            set = new GenericSet<string>();
        }

        [Test]
        public void AddTest()
        {
            set.Add("Misha");
            Assert.AreEqual(1, set.Count);
        }

        [Test]
        public void AddingAnItemThatIsAlreadyContainedInSetTest()
        {
            set.Add("Misha");
            Assert.AreEqual(1, set.Count);
            set.Add("Misha");
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
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            set.Add("Four");
            set.Add("Five");
            Assert.AreEqual(5, set.Count);
            set.Clear();
            Assert.AreEqual(0, set.Count);
        }

        [Test]
        public void RemoveTest()
        {
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            set.Add("Four");
            set.Add("Five");
            Assert.AreEqual(5, set.Count);
            Assert.IsTrue(set.Contains("One"));
            set.Remove("One");
            Assert.AreEqual(4, set.Count);
            Assert.IsFalse(set.Contains("One"));
            Assert.IsTrue(set.Contains("Five"));
        }

        [Test]
        public void ContainsTest()
        {
            set.Add("Three");
            set.Add("Four");
            set.Add("Five");
            Assert.IsTrue(set.Contains("Five"));
            Assert.IsTrue(set.Contains("Four"));
            Assert.IsTrue(set.Contains("Three"));
            Assert.IsFalse(set.Contains("DabDabDab"));
            Assert.IsFalse(set.Contains("John Snow"));
        }

        [Test]
        public void CopyToTest()
        {
            set.Add("1");
            set.Add("2");
            set.Add("3");
            set.Add("4");
            set.Add("5");
            var array = new string[5];
            set.CopyTo(array, 0);
            Assert.AreEqual("1", array[0]);
            Assert.AreEqual("2", array[1]);
            Assert.AreEqual("3", array[2]);
            Assert.AreEqual("4", array[3]);
            Assert.AreEqual("5", array[4]);
        }

        [Test]
        public void ExceptWithTest()
        {
            var someSet = new GenericSet<string>();
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            set.Add("Four");
            set.Add("Five");
            someSet.Add("Ten");
            someSet.Add("Eleven");
            someSet.Add("Twelve");
            someSet.Add("Three");
            someSet.ExceptWith(set);
            Assert.IsFalse(someSet.Contains("Three"));
            Assert.IsTrue(someSet.Contains("Eleven"));
            Assert.IsTrue(someSet.Contains("Twelve"));
            Assert.IsTrue(someSet.Contains("Ten"));
            Assert.AreEqual(3, someSet.Count);
        }

        [Test]
        public void IntersectWithTest()
        {
            var someSet = new GenericSet<string>();
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            set.Add("Four");
            set.Add("Five");
            someSet.Add("Ten");
            someSet.Add("Twenty");
            someSet.Add("Eleven");
            someSet.Add("Twelve");
            someSet.Add("Seven");
            someSet.IntersectWith(set);
            Assert.IsFalse(someSet.Contains("Ten"));
            Assert.IsFalse(someSet.Contains("Twenty"));
            Assert.IsFalse(someSet.Contains("Eleven"));
            Assert.IsFalse(someSet.Contains("Twelve"));
            Assert.IsFalse(someSet.Contains("Seven"));
            Assert.AreEqual(0, someSet.Count);
        }

        [Test]
        public void IsProperSubsetOfTest()
        {
            var someSet = new GenericSet<string>();
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            set.Add("Four");
            set.Add("Five");
            someSet.Add("Three");
            someSet.Add("Two");
            someSet.Add("Five");
            Assert.IsTrue(someSet.IsProperSubsetOf(set));
        }

        [Test]
        public void IsProperSupersetOfTest()
        {
            var someSet = new GenericSet<string>();
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            set.Add("Four");
            someSet.Add("Three");
            someSet.Add("Two");
            someSet.Add("Four");
            Assert.IsFalse(someSet.IsProperSupersetOf(set));
        }

        [Test]
        public void IsSubsetOfTest()
        {
            var someSet = new GenericSet<string>();
            set.Add("1");
            set.Add("2");
            set.Add("3");
            set.Add("4");
            someSet.Add("3");
            someSet.Add("4");
            Assert.IsTrue(someSet.IsSubsetOf(set));
        }

        [Test]
        public void IsSupersetOfTest()
        {
            var someSet = new GenericSet<string>();
            set.Add("1");
            set.Add("2");
            set.Add("3");
            set.Add("4");
            someSet.Add("4");
            someSet.Add("2");
            someSet.Add("3");
            someSet.Add("1");
            Assert.IsTrue(someSet.IsSupersetOf(set));
        }

        [Test]
        public void OverlapsTest()
        {
            var someSet = new GenericSet<string>();
            set.Add("5");
            set.Add("6");
            set.Add("7");
            set.Add("8");
            set.Add("9");
            someSet.Add("1");
            someSet.Add("2");
            someSet.Add("3");
            someSet.Add("4");
            Assert.IsFalse(someSet.Overlaps(set));
        }

        [Test]
        public void SetEqualsTest()
        {
            var someSet = new GenericSet<string>();
            set.Add("5");
            set.Add("6");
            set.Add("7");
            set.Add("8");
            set.Add("9");
            someSet.Add("6");
            someSet.Add("8");
            someSet.Add("5");
            someSet.Add("0");
            someSet.Add("9");
            someSet.Add("7");
            Assert.IsFalse(someSet.SetEquals(set));
        }

        [Test]
        public void SymmetricExceptWithTest()
        {
            var someSet = new GenericSet<string>();
            set.Add("1");
            set.Add("2");
            set.Add("3");
            set.Add("4");
            set.Add("5");
            someSet.Add("1");
            someSet.Add("2");
            someSet.Add("3");
            someSet.Add("4");
            someSet.Add("5");
            someSet.SymmetricExceptWith(set);
            Assert.IsFalse(someSet.Contains("1"));
            Assert.IsFalse(someSet.Contains("2"));
            Assert.IsFalse(someSet.Contains("3"));
            Assert.IsFalse(someSet.Contains("4"));
            Assert.IsFalse(someSet.Contains("5"));
            Assert.AreEqual(0, someSet.Count);
        }

        [Test]
        public void UnionWithTest()
        {
            var someSet = new GenericSet<string>();
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            someSet.Add("Five");
            someSet.Add("Six");
            someSet.UnionWith(set);
            Assert.IsTrue(someSet.Contains("Three"));
            Assert.IsTrue(someSet.Contains("One"));
            Assert.IsTrue(someSet.Contains("Six"));
            Assert.IsTrue(someSet.Contains("Five"));
            Assert.IsTrue(someSet.Contains("Two"));
            Assert.AreEqual(5, someSet.Count);
        }
    }
}
