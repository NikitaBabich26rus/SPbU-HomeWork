using NUnit.Framework;

namespace _2._3._2
{
    public class HashTableTests
    {

        HashTable tableWithFirstFunction;
        HashTable tableWithSecondFunction;

        [SetUp]
        public void Setup()
        {
            tableWithFirstFunction = new HashTable(new HashFunction1());
            tableWithSecondFunction = new HashTable(new HashFunction2());
        }

        [Test]
        public void IsContainInEmptyHashTableTest()
        {
            Assert.IsFalse(tableWithFirstFunction.IsContain("1234"));
            Assert.IsFalse(tableWithSecondFunction.IsContain("1234"));
        }

        [Test]
        public void DeleteFromEmptyTest()
        {
            tableWithFirstFunction.Remove("HwProj");
            tableWithSecondFunction.Remove("HwProj");
        }

        [Test]
        public void HashTableResizeTest()
        {
            Assert.AreEqual(2, tableWithFirstFunction.GetHashTableSize());
            tableWithFirstFunction.Add("One");
            tableWithFirstFunction.Add("Two");
            tableWithFirstFunction.Add("Three");
            Assert.AreEqual(4, tableWithFirstFunction.GetHashTableSize());
            Assert.IsTrue(tableWithFirstFunction.IsContain("One"));
            Assert.IsTrue(tableWithFirstFunction.IsContain("Two"));
            Assert.IsTrue(tableWithFirstFunction.IsContain("Three"));

            Assert.AreEqual(2, tableWithSecondFunction.GetHashTableSize());
            tableWithSecondFunction.Add("One");
            tableWithSecondFunction.Add("Two");
            tableWithSecondFunction.Add("Three");
            Assert.AreEqual(4, tableWithSecondFunction.GetHashTableSize());
            Assert.IsTrue(tableWithSecondFunction.IsContain("One"));
            Assert.IsTrue(tableWithSecondFunction.IsContain("Two"));
            Assert.IsTrue(tableWithSecondFunction.IsContain("Three"));
        }

        [Test]
        public void ChangeHashFunctionTest()
        {
            tableWithFirstFunction.Add("Test");
            tableWithFirstFunction.ChangeHashFunction(new HashFunction2());
            Assert.IsTrue(tableWithFirstFunction.IsContain("Test"));

            tableWithSecondFunction.Add("Test");
            tableWithSecondFunction.ChangeHashFunction(new HashFunction1());
            Assert.IsTrue(tableWithSecondFunction.IsContain("Test"));

            tableWithFirstFunction.ChangeHashFunction(new HashFunction1());
            tableWithSecondFunction.ChangeHashFunction(new HashFunction2());
        }

        [Test]
        public void AddTest()
        {
            tableWithFirstFunction.Add("Hello");
            Assert.IsTrue(tableWithFirstFunction.IsContain("Hello"));
            tableWithSecondFunction.Add("Hello");
            Assert.IsTrue(tableWithSecondFunction.IsContain("Hello"));
        }

        [Test]
        public void ManyAddTest()
        {
            for (int i = 0; i <= 10000; i++)
            {
                tableWithFirstFunction.Add(i.ToString());
                tableWithSecondFunction.Add(i.ToString());
            }

            for (int i = 0; i <= 10000; i++)
            {
                Assert.IsTrue(tableWithFirstFunction.IsContain(i.ToString()));
                Assert.IsTrue(tableWithSecondFunction.IsContain(i.ToString()));
            }
        }

        [Test]
        public void DeleteElementInHashTableTest()
        {
            tableWithFirstFunction.Add("Goodbye");
            tableWithFirstFunction.Remove("Goodbye");
            Assert.IsFalse(tableWithFirstFunction.IsContain("Goodbye"));

            tableWithSecondFunction.Add("Goodbye");
            tableWithSecondFunction.Remove("Goodbye");
            Assert.IsFalse(tableWithSecondFunction.IsContain("Goodbye"));
        }

        [Test]
        public void ManyPushAndDeleteTest()
        {
            for (int i = 10001; i <= 20000; i++)
            {
                tableWithFirstFunction.Add(i.ToString());
                tableWithSecondFunction.Add(i.ToString());
            }
            for (int i = 10001; i <= 20000; i++)
            {
                tableWithFirstFunction.Remove(i.ToString());
                tableWithSecondFunction.Remove(i.ToString());
            }
            for (int i = 10001; i <= 20000; i++)
            {
                Assert.IsFalse(tableWithFirstFunction.IsContain(i.ToString()));
                Assert.IsFalse(tableWithSecondFunction.IsContain(i.ToString()));

            }
        }

    }

}