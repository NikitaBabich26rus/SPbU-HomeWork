using NUnit.Framework;
using System;

namespace CalculatorForm
{
    public class Tests
    {
        private CalculatorLogic calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new CalculatorLogic();
        }

        [Test]
        public void AdditionWithZeroTest()
        {
            calculator.AddNumber("5");
            calculator.AddOperation("+");
            calculator.AddNumber("0");
            calculator.Counting();
            Assert.AreEqual(5, Convert.ToDouble(calculator.CurrentEntry));
        }

        [Test]
        public void SubtractionWithZeroTest()
        {
            calculator.AddNumber("0");
            calculator.AddOperation("-");
            calculator.AddNumber("3");
            calculator.Counting();
            Assert.AreEqual(-3, Convert.ToDouble(calculator.CurrentEntry));
        }

        [Test]
        public void MultiplicationWithZeroTest()
        {
            calculator.AddNumber("0");
            calculator.AddOperation("*");
            calculator.AddNumber("3");
            calculator.Counting();
            Assert.AreEqual(0, Convert.ToDouble(calculator.CurrentEntry));
        }

        [Test]
        public void DivisionByZeroTest()
        {
            calculator.AddNumber("6");
            calculator.AddOperation("/");
            calculator.AddNumber("0");
            Assert.Throws<DivideByZeroException>(() => calculator.Counting()); 
        }

        [Test]
        public void AdditionWithLargeNumbersTest()
        {
            calculator.AddNumber("5131212");
            calculator.AddOperation("+");
            calculator.AddNumber("3132133");
            calculator.Counting();
            Assert.AreEqual(8263345, Convert.ToDouble(calculator.CurrentEntry));
        }

        [Test]
        public void SubtractionWithLargeNumbersTest()
        {
            calculator.AddNumber("5131212");
            calculator.AddOperation("-");
            calculator.AddNumber("3132133");
            calculator.Counting();
            Assert.AreEqual(1999079, Convert.ToDouble(calculator.CurrentEntry));
        }

        [Test]
        public void MultiplicationWithLargeNumbersTest()
        {
            calculator.AddNumber("513121");
            calculator.AddOperation("*");
            calculator.AddNumber("3132133");
            calculator.Counting();
            Assert.AreEqual(1607163217093, Convert.ToDouble(calculator.CurrentEntry));
        }

        [Test]
        public void DivisionWithLargeNumbersTest()
        {
            calculator.AddNumber("50000000");
            calculator.AddOperation("/");
            calculator.AddNumber("10000000");
            calculator.Counting();
            Assert.AreEqual(5, Convert.ToDouble(calculator.CurrentEntry));
        }
    }
}