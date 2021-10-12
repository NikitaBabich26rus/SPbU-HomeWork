using NUnit.Framework;

namespace _2._7._1
{
    public class ButtonsToClearCalculatorFields
    {
        private CalculatorLogic calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new CalculatorLogic();
        }

        [Test]
        public void ClickOnThBackspaceButtonTest()
        {
            calculator.AddNumber("1");
            Assert.AreEqual("1", calculator.CurrentEntry);
            calculator.Backspace();
            Assert.AreEqual("", calculator.CurrentEntry);
        }

        [Test]
        public void ManyClicksOnTheBackspaceButton()
        {
            for (int i = 0; i < 5; i++)
            {
                calculator.AddNumber("1");
            }
            Assert.AreEqual("11111", calculator.CurrentEntry);
            for (int i = 0; i < 10; i++)
            {
                calculator.Backspace();
            }
            Assert.AreEqual("", calculator.CurrentEntry);
        }

        [Test]
        public void ClickOnTheBackspaceButtonAfterCountingTest()
        {
            calculator.AddNumber("5");
            calculator.AddOperation("+");
            calculator.AddNumber("3");
            calculator.Counting();
            calculator.Backspace();
            Assert.AreEqual("", calculator.CurrentEntry);
        }

        [Test]
        public void ClickOnTheClearEntryButtonBeforeAddOperationTest()
        {
            for (int i = 0; i < 5; i++)
            {
                calculator.AddNumber("1");
            }
            Assert.AreEqual("11111", calculator.CurrentEntry);
            calculator.ClearEntry();
            Assert.AreEqual("", calculator.CurrentEntry);
        }

        [Test]
        public void ClickOnTheClearEntryButtonAfterAddOperationTest()
        {
            calculator.AddNumber("1");
            calculator.AddOperation("+");
            for (int i = 0; i < 5; i++)
            {
                calculator.AddNumber("1");
            }
            calculator.ClearEntry();
            Assert.AreEqual("", calculator.CurrentEntry);
        }

        [Test]
        public void ClickOnTheClearEntryButtonAfterCountingTest()
        {
            calculator.AddNumber("1");
            calculator.AddOperation("+");
            calculator.AddNumber("9");
            calculator.Counting();
            calculator.ClearEntry();
            Assert.AreEqual("", calculator.CurrentEntry);
        }

        [Test]
        public void ClickOnTheClearEntryButtonDuringExpressionCountingTest()
        {
            calculator.AddNumber("1");
            calculator.AddOperation("+");
            calculator.AddNumber("9");
            calculator.AddOperation("+");
            calculator.AddNumber("3");
            calculator.AddOperation("+");
            calculator.ClearEntry();
            Assert.AreEqual("", calculator.CurrentEntry);
            calculator.AddNumber("2");
            calculator.Counting();
            Assert.AreEqual("15", calculator.CurrentEntry);
        }

        [Test]
        public void ClickOnTheClearButton()
        {
            calculator.AddNumber("1");
            calculator.AddOperation("+");
            calculator.AddNumber("9");
            calculator.Counting();
            calculator.Clear();
            Assert.AreEqual("", calculator.CurrentEntry);
            Assert.AreEqual("", calculator.CurrentExpression);
        }
    }
}
