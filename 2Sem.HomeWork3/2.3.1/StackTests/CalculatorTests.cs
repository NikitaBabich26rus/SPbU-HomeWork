using System;
using NUnit.Framework;
using System.Collections;


namespace _2._3._1
{
    public class CalculatorTests
    { 
        private string expression;

        [SetUp]
        public void SetUp()
        {
            expression = "";
        }

        [Test]
        public void AdditionOfLargeElementsTest()
        {
            expression = "999999 999999 +";
            Assert.AreEqual(1999998, Calculator.Counting(expression, true).Item1);
            Assert.AreEqual(1999998, Calculator.Counting(expression, false).Item1);
        }

        [Test]
        public void AdditionOfSmallAndLargeElementsTest()
        {
            expression = "1 999999 +";
            Assert.AreEqual(1000000, Calculator.Counting(expression, true).Item1);
            Assert.AreEqual(1000000, Calculator.Counting(expression, false).Item1);
        }

        [Test]
        public void ManyAdditionTest()
        {
            expression = "1 2 3 4 5 6 7 8 9 10 + + + + + + + + +";
            Assert.AreEqual(55, Calculator.Counting(expression, true).Item1);
            Assert.AreEqual(55, Calculator.Counting(expression, false).Item1);
        }

        [Test]
        public void SubtractionOfTwoElementsTest()
        {
            expression = "1 999999 -";
            Assert.AreEqual(-999998, Calculator.Counting(expression, true).Item1);
            Assert.AreEqual(-999998, Calculator.Counting(expression, false).Item1);
        }

         [Test]
        public void MultiplicationOfTwoLargeElementsTest()
        {
            expression = "22888 31415 *";
            Assert.AreEqual(719026520, Calculator.Counting(expression, true).Item1);
            Assert.AreEqual(719026520, Calculator.Counting(expression, false).Item1);
        }

        [Test]
        public void MultiplicationOfZeroAndLargeElementTest()
        {
            expression = "0 999999 *";
            Assert.AreEqual(0, Calculator.Counting(expression, true).Item1);
            Assert.AreEqual(0, Calculator.Counting(expression, false).Item1);
        }

        [Test]
        public void FusedExpression()
        {
            expression = "9992131+";
            Calculator.Counting(expression, true);
            Calculator.Counting(expression, false);
        }

        [Test]
        public void ExpressionSymbolsMoreThanElemenstTest()
        {
            expression = "1 1 1 + + + + +";
            Calculator.Counting(expression, true);
            Calculator.Counting(expression, false);
        }

        [Test]
        public void ExpressionWithoutOfNumbersTest()
        {
            expression = "++-+++efweef-+-/-";
            Calculator.Counting(expression, true);
            Calculator.Counting(expression, false);
        }

        [Test]
        public void RandomTextTest()
        {
            expression = "Is education residence conveying so so. Suppose shyness say ten behaved morning had.";
            Calculator.Counting(expression, true);
            Calculator.Counting(expression, false);
        }

        [Test]
        public void InfixNotationTestTest()
        {
            expression = "13123 / 312121";
            Calculator.Counting(expression, true);
            Calculator.Counting(expression, false);
        }

        [Test]
        public void ExpressionWhithNumbersMultiplicationSymbolsAndRandomSymbolsTest()
        {
            expression = "1a %2 3 * a *.";
            Calculator.Counting(expression, true);
            Calculator.Counting(expression, false);
        }

        [Test]
        public void EmptyExpressionTest()
        {
            expression = "";
            Calculator.Counting(expression, true);
            Calculator.Counting(expression, false);
        }
    }
}
