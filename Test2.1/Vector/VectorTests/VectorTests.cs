using NUnit.Framework;
using System.Numerics;
using Vector;

namespace VectorTests
{
    public class Tests
    {
        private VectorOnList vector1;
        private VectorOnList vector2;
        private VectorOnList answerVector;

        [SetUp]
        public void Setup()
        {
            vector1 = new VectorOnList(new int[3] { 1, 2, 3 });
            vector2 = new VectorOnList(new int[3] { 4, 5, 6 });
        }

        [Test]
        public void VectorsAdditionTest()
        {
            answerVector = VectorsOperations.Addition(vector1, vector2);
            int[] answerArray = answerVector.GetVectorArray();
            Assert.AreEqual(5, answerArray[0]);
            Assert.AreEqual(7, answerArray[1]);
            Assert.AreEqual(9, answerArray[2]);
        }

        [Test]
        public void VectorsSubstractionTest()
        {
            answerVector = VectorsOperations.Subtraction(vector2, vector1);
            int[] answerArray = answerVector.GetVectorArray();
            Assert.AreEqual(3, answerArray[0]);
            Assert.AreEqual(3, answerArray[1]);
            Assert.AreEqual(3, answerArray[2]);
        }

        [Test]
        public void VectorsScalarMultiplicationTest()
        {
            int answer = VectorsOperations.ScalarMultiplication(vector1, vector2);
            Assert.AreEqual(32, answer);
        }
    }
}