using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace _2._3._2
{
    public class HashTableTests
    {
        private HashTable hashTable;

        [TestCaseSource(nameof(HashFunctions))]
        public void IsContainInEmptyHashTableTest(IHashFunction hashFunction)
        {
            hashTable = new HashTable(hashFunction);
            Assert.IsFalse(hashTable.IsContain("1234"));
        }

        [TestCaseSource(nameof(HashFunctions))]
        public void DeleteFromEmptyTest(IHashFunction hashFunction)
        {
            hashTable = new HashTable(hashFunction);
            hashTable.Remove("HwProj");
        }

        [TestCaseSource(nameof(HashFunctions))]
        public void HashTableResizeTest(IHashFunction hashFunction)
        {
            hashTable = new HashTable(hashFunction);
            hashTable.Add("One");
            hashTable.Add("Two");
            hashTable.Add("Three");
            Assert.IsTrue(hashTable.IsContain("One"));
            Assert.IsTrue(hashTable.IsContain("Two"));
            Assert.IsTrue(hashTable.IsContain("Three"));
        }

        [TestCaseSource(nameof(HashFunctions))]
        public void ChangeHashFunctionTest(IHashFunction hashFunction)
        {
            hashTable = new HashTable(hashFunction);
            hashTable.Add("Test");
            hashTable.ChangeHashFunction(new HashFunction2());
            Assert.IsTrue(hashTable.IsContain("Test"));

            hashTable.ChangeHashFunction(new HashFunction1());
            Assert.IsTrue(hashTable.IsContain("Test"));
        }

        [TestCaseSource(nameof(HashFunctions))]
        public void AddTest(IHashFunction hashFunction)
        {
            hashTable = new HashTable(hashFunction);
            hashTable.Add("Hello");
            Assert.IsTrue(hashTable.IsContain("Hello"));
        }

        [TestCaseSource(nameof(HashFunctions))]
        public void ManyAddTest(IHashFunction hashFunction)
        {
            hashTable = new HashTable(hashFunction);
            for (int i = 0; i <= 10000; i++)
            {
                hashTable.Add(i.ToString());
            }

            for (int i = 0; i <= 10000; i++)
            {
                Assert.IsTrue(hashTable.IsContain(i.ToString()));
            }
        }

        [TestCaseSource(nameof(HashFunctions))]
        public void DeleteElementInHashTableTest(IHashFunction hashFunction)
        {
            hashTable = new HashTable(hashFunction);
            hashTable.Add("Goodbye");
            hashTable.Remove("Goodbye");
            Assert.IsFalse(hashTable.IsContain("Goodbye"));
        }

        [TestCaseSource(nameof(HashFunctions))]
        public void ManyPushAndDeleteTest(IHashFunction hashFunction)
        {
            hashTable = new HashTable(hashFunction);
            for (int i = 10001; i <= 20000; i++)
            {
                hashTable.Add(i.ToString());
            }
            for (int i = 10001; i <= 20000; i++)
            {
                hashTable.Remove(i.ToString());
            }
            for (int i = 10001; i <= 20000; i++)
            {
                Assert.IsFalse(hashTable.IsContain(i.ToString()));
            }
        }

        private static IEnumerable<TestCaseData> HashFunctions
        => new TestCaseData[]
        {
            new TestCaseData(new HashFunction1()),
            new TestCaseData(new HashFunction2()),
        };
    }
}