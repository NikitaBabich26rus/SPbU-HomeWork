using System;

namespace _2._7._1
{
    /// <summary>
    /// Сalculator calculation logicю
    /// </summary>
    public class CalculatorLogic
    {
        /// <summary>
        /// Expression with current numbers and operations.
        /// </summary>
        public string CurrentExpression { get; private set; } = "";

        /// <summary>
        /// Current entry string
        /// </summary>
        public string CurrentEntry { get; private set; } = "";

        private string[] expression = new string[2] { "", "" };
        private char operation;
        private bool isOperationSelected = false;
        private bool isEqualSign = true;

        /// <summary>
        /// Add number in expression.
        /// </summary>
        /// <param name="number">Number</param>
        public void AddNumber(string number)
        {
            if (!isOperationSelected)
            {
                expression[0] += number;
                CurrentEntry = expression[0];
                return;
            }
            expression[1] += number;
            CurrentEntry = expression[1];
            isEqualSign = true;
        }

        /// <summary>
        /// Add operation in expression.
        /// </summary>
        /// <param name="sign">Operation`s sign</param>
        public void AddOperation(string sign)
        {
            if (expression[0].Length == 0)
            {
                return;
            }
            char[] operationArray = sign.ToCharArray();
            if (expression[1].Length != 0)
            {
                CurrentExpression += " " + expression[1] + " " + sign;
                double result = GetOperationResult(operation, Convert.ToDouble(expression[0]), Convert.ToDouble(expression[1]));
                CurrentEntry = result.ToString();
                expression[0] = CurrentEntry;
                expression[1] = "";
                isEqualSign = false;
                operation = operationArray[0];
                return;
            }
            operation = operationArray[0];
            CurrentExpression = expression[0] + " " + operation;
            isOperationSelected = true;
        }

        /// <summary>
        /// Counting operation.
        /// </summary>
        public void Counting()
        {
            if (expression[0].Length == 0 || expression[1].Length == 0)
            {
                return;
            }
            isOperationSelected = false;
            isEqualSign = true;
            CurrentExpression += " " + expression[1] + " =";
            double result = GetOperationResult(operation, Convert.ToDouble(expression[0]), Convert.ToDouble(expression[1]));
            CurrentEntry = result.ToString();
            expression[0] = CurrentEntry;
            expression[1] = "";
        }

        /// <summary>
        /// Get result of operation
        /// </summary>
        /// <param name="operation">Operation`s sign</param>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <returns>Result</returns>
        private double GetOperationResult(char operation, double value1, double value2)
        {
            double result = 0;
            switch (operation)
            {
                case '+':
                    result = value1 + value2;
                    break;

                case '-':
                    result = value1 - value2;
                    break;

                case '*':
                    result = value1 * value2;
                    break;

                case '/':
                    if (value2 == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    result = value1 / value2;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Change number`s sign.
        /// </summary>
        public void ChangeSgn()
        {
            if (CurrentEntry.Length == 0)
            {
                return;
            }
            double changeValueSgn = -1 * Convert.ToDouble(CurrentEntry);
            if (isEqualSign && CurrentEntry == expression[0])
            {
                CurrentEntry = changeValueSgn.ToString();
                expression[0] = CurrentEntry;
                CurrentExpression = "";
                return;
            }
            if (CurrentEntry == expression[0])
            {
                expression[0] = changeValueSgn.ToString();
                CurrentEntry = expression[0];
                return;
            }
            expression[1] = changeValueSgn.ToString();
            CurrentEntry = expression[1];
        }

        /// <summary>
        /// Delete last number.
        /// </summary>
        public void Backspace()
        {
            if (CurrentEntry.Length == 0 || !isEqualSign || (isOperationSelected && CurrentEntry == expression[0]))
            {
                return;
            }
            if (CurrentEntry == expression[0])
            {
                expression[0] = expression[0].Substring(0, expression[0].Length - 1);
                CurrentEntry = CurrentEntry.Substring(0, CurrentEntry.Length - 1);
                return;
            }
            expression[1] = expression[1].Substring(0, expression[1].Length - 1);
            CurrentEntry = CurrentEntry.Substring(0, CurrentEntry.Length - 1);
        }

        /// <summary>
        /// Clear entry string.
        /// </summary>
        public void ClearEntry()
        {
            if (CurrentEntry.Length == 0)
            {
                return;
            }
            if (!isEqualSign && CurrentEntry == expression[0])
            {
                CurrentEntry = "";
                return;
            }
            if (isEqualSign && CurrentEntry == expression[0])
            {
                Clear();
                return;
            }
            if (CurrentEntry == expression[0])
            {
                CurrentEntry = "";
                expression[0] = "";
                return;
            }
            CurrentEntry = "";
            expression[1] = "";
        }

        /// <summary>
        /// Clear all calculator fields.
        /// </summary>
        public void Clear()
        {
            expression[0] = "";
            expression[1] = "";
            CurrentEntry = "";
            CurrentExpression = "";
            isOperationSelected = false;
            isEqualSign = true;
        }

        /// <summary>
        /// Add comma to number.
        /// </summary>
        public void AddComma()
        {
            if (CurrentEntry.Length == 0)
            {
                return;
            }
            double integerPartOfValue = Math.Truncate(Convert.ToDouble(CurrentEntry));
            if (integerPartOfValue != Convert.ToDouble(CurrentEntry))
            {
                return;
            }
            if (isEqualSign && CurrentEntry == expression[0])
            {
                CurrentEntry += ",";
                expression[0] = CurrentEntry;
                CurrentExpression = "";
                return;
            }
            if (CurrentEntry == expression[0])
            {
                expression[0] += ",";
                CurrentEntry = expression[0];
                return;
            }
            expression[1] += ",";
            CurrentEntry = expression[1];
        }
    }
}