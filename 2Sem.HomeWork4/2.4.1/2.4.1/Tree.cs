using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._1
{
	/// <summary>
	/// Tree's class
	/// </summary>
	public class Tree
    {
		private INode root { get; set; }

		/// <summary>
		/// Check expression for correct
		/// </summary>
		/// <param name="expression">String with expression</param>
		/// <returns>Correct of not</returns>
		public bool IsExpressionCorrect(string expression)
		{
			int amountOfValues = 0;

			for (int i = 0; i < expression.Length; i++)
			{
				if (expression[i] == ' ' || expression[i] == ')' || expression[i] == '(')
				{
					continue;
				}
				else if (char.IsDigit(expression[i]))
				{
					CreateNumber(ref i, expression);
					amountOfValues++;
					continue;
				}
				else if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
				{
					amountOfValues--;
				}
				else
				{
					return false;
				}
			}

			if (amountOfValues == 0)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Create the tree by expression
		/// </summary>
		/// <param name="str">String with expression</param>
		public void BuildTree(string str)
		{
			if (!IsExpressionCorrect(str))
			{
				throw new Exception();
			}
			int counter = 0;
			root = AddElementInTree(str, ref counter);
		}

		/// <summary>
		/// Get operation for counting
		/// </summary>
		/// <param name="operation">Addition, division, multiplication or subtraction</param>
		/// <returns>Operation</returns>
		private Operation ChoiceOperation(char operation)
		{
			if (operation == '+')
			{
				return new Addition();
			}

			if (operation == '-')
			{
				return new Subtraction();
			}

			if (operation == '*')
			{
				return new Multiplication();
			}

			return new Division();
		}

		/// <summary>
		/// Add element in tree
		/// </summary>
		/// <param name="str">String with expression</param>
		/// <param name="counter">Counter of string</param>
		/// <returns>New tree element</returns>
		private INode AddElementInTree(string str, ref int counter)
		{
			if (counter == str.Length)
			{
				return null;
			}

			while (str[counter] == '(' || str[counter] == ')' || str[counter] == ' ')
			{
				counter++;
				if (counter == str.Length)
				{
					return null;
				}
			}
			
			if (char.IsDigit(str[counter]))
			{
				int value = CreateNumber(ref counter, str);
				return new Number(value);
			}
			else
			{
				char operation = str[counter];
				counter++;
				var newElement = ChoiceOperation(operation);

				newElement.LeftChild = AddElementInTree(str, ref counter);
				newElement.RightChild = AddElementInTree(str, ref counter);
				return newElement;
			}
		}

		/// <summary>
		/// Get number from string
		/// </summary>
		/// <param name="position">Counter of string</param>
		/// <param name="expression">String of expression</param>
		/// <returns>Number</returns>
		private static int CreateNumber(ref int position, string expression)
		{
			string value = null;

			while (char.IsDigit(expression[position]))
			{
				value += expression[position];
				position++;
			}

			return int.Parse(value);
		}

		/// <summary>
		/// Counting expression
		/// </summary>
		/// <returns>Result of expression</returns>
		public double Counting() => root.Counting();

		/// <summary>
		/// Output exxpression
		/// </summary>
		public void OutputTree()
		{
			root.Print();
		}
	}
}
