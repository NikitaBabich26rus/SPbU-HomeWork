using NUnit.Framework;
using System;
using System.Data;

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
            Assert.AreEqual(1.5, tree.Counting());
        }

        [Test]
        public void ExpressionWithAdditionTest()
        {
            tree.BuildTree("(+ 12 3)");
            Assert.AreEqual(15, tree.Counting());
        }

        [Test]
        public void ExpressionWithSubtractionTest()
        {
            tree.BuildTree("(- 13 3)");
            Assert.AreEqual(10, tree.Counting());
        }

        [Test]
        public void ExpressionWithMultiplicationTest()
        {
            tree.BuildTree("(* 9 9)");
            Assert.AreEqual(81, tree.Counting());
        }

        [Test]
        public void ExpressionWithAllOperationTest()
        {
            tree.BuildTree("( * (/ (+ 12 3) (- 6 1)) 10 )");
            Assert.AreEqual(30, tree.Counting());
        }

        [Test]
        public void InvalidExpressionTest()
        {
            Assert.Throws<InvalidExpressionException>(() => tree.BuildTree("( * (/ (+ 12 3) (- 6 1)))"));
        }
    }
}
