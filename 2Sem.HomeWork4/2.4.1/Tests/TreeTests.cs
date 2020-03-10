using NUnit.Framework;

namespace _2._4._1
{
    class TreeTests
    {
        Tree tree;

        [SetUp]
        public void Setup()
        {
            tree = new Tree();
        }

        [Test]
        public void ExpressionWithDivisionTest()
        {
            tree.BuildTree("(/ 3 2)");
            Assert.AreEqual(tree.Counting(), 1,5);
        }

        [Test]
        public void ExpressionWithAdditionTest()
        {
            tree.BuildTree("(+ 12 3)");
            Assert.AreEqual(tree.Counting(), 15);
        }

        [Test]
        public void ExpressionWithSubtractionTest()
        {
            tree.BuildTree("(- 13 3)");
            Assert.AreEqual(tree.Counting(), 10);
        }

        [Test]
        public void ExpressionWithMultiplicationTest()
        {
            tree.BuildTree("(* 9 9)");
            Assert.AreEqual(tree.Counting(), 81);
        }

        [Test]
        public void ExpressionWithAllOperationTest()
        {
            tree.BuildTree("( * (/ (+ 12 3) (- 6 1)) 10 )");
            Assert.AreEqual(tree.Counting(), 30);
        }

        [Test]
        public void InvalidExpressionTest()
        {
            tree.BuildTree("( * (/ (+ 12 3) (- 6 1)))");
            tree.Counting();
        }
    }
}
