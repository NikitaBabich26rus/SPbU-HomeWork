using NUnit.Framework;
using System;

namespace _2._7._1
{
    public class CalculatorExpressionTests
    {
        private CalculatorLogic calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new CalculatorLogic();
        }

        [Test]
        public void ExpressionWithAdditionAndClickClearEntryButtonTest()
        {
            calculator.AddNumber("5");
            calculator.AddComma();
            calculator.AddNumber("2");
            calculator.AddOperation("+");
            calculator.AddNumber("1");
            calculator.AddComma();
            calculator.AddNumber("1");
            calculator.Counting();
            Assert.AreEqual(6, 3, Convert.ToDouble(calculator.CurrentEntry));
            calculator.ClearEntry();
            Assert.AreEqual("", calculator.CurrentEntry);
            Assert.AreEqual("", calculator.CurrentExpression);
        }

        [Test]
        public void ExpressionWithoutClickEqualSignButtonAndClickClearButtonTest()
        {
            calculator.AddNumber("5");
            calculator.AddComma();
            calculator.AddNumber("2");
            calculator.AddOperation("+");
            calculator.AddNumber("1");
            calculator.AddComma();
            calculator.AddNumber("1");
            calculator.AddOperation("-");
            calculator.AddNumber("3");
            calculator.AddComma();
            calculator.AddNumber("1");
            calculator.AddOperation("+");
            calculator.AddNumber("1");
            calculator.AddComma();
            calculator.AddNumber("9");
            Assert.AreEqual("1,9", calculator.CurrentEntry);
            calculator.Clear();
            Assert.AreEqual("", calculator.CurrentEntry);
            Assert.AreEqual("", calculator.CurrentExpression);
        }

        [Test]
        public void ExpressionWithAdditionAndClickChangeSgnTest()
        {
            calculator.AddNumber("5");
            calculator.AddOperation("+");
            calculator.AddNumber("1");
            calculator.Counting();
            Assert.AreEqual(6, Convert.ToDouble(calculator.CurrentEntry));
            calculator.ChangeSgn();
            Assert.AreEqual(-6, Convert.ToDouble(calculator.CurrentEntry));
            calculator.AddNumber("6");
            calculator.AddOperation("+");
            calculator.AddNumber("3");
            calculator.Counting();
            Assert.AreEqual(-63, Convert.ToDouble(calculator.CurrentEntry));
        }

        [Test]
        public void ExpressionWithClickCommaButtonWithoutNonIntegerPartOfNumber()
        {
            calculator.AddNumber("5");
            calculator.AddComma();
            calculator.AddOperation("+");
            calculator.AddNumber("1");
            calculator.AddComma();
            calculator.Counting();
            Assert.AreEqual(6, Convert.ToDouble(calculator.CurrentEntry));
        }
    }
}
