using System;
using System.Collections.Generic;
using System.Text;

namespace _2._3._1
{
	public class Calculator
	{

		private static IStack stack;

		/// <summary>
		/// Create number by position in string  
		/// </summary>
		/// <param name="position">First number position in string</param>
		/// <param name="expression"></string with expression>
		/// <returns></returns>
		private static int CreateNumber(ref int position, string expression)
		{
			string value = null;

			while (char.IsDigit(expression[position]))
			{
				value += expression[position];
				position++;
			}

			position--;
			return int.Parse(value);
		}

		/// <summary>
		/// Сhecking the string for correctness
		/// </summary>
		/// <param name="expression">String with expression</param>
		/// <returns>Result: correct expression or not</returns>
		public static bool IsExpressionCorrect(string expression)
		{
			int amountOfValues = 0;

			for (int i = 0; i < expression.Length; i++)
			{
				if (expression[i] == ' ')
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
					if (amountOfValues < 2)
					{
						return false;
					}
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
		/// Counting of expression
		/// </summary>
		/// <param name="expression"></string with expression>
		/// <param name="choice"></Variable for stack selection>
		/// <returns>Result of expression</returns>
		public static (int, bool) Counting(string expression, bool choice)
		{

			if (!IsExpressionCorrect(expression))
			{
				return (0, false);
			}

			if (choice)
			{
				stack = new ListStack();
			}

			else
			{
				stack = new ArrayStack();
			}

			for (int i = 0; i < expression.Length; i++)
			{
				char symbol = expression[i];

				if (char.IsDigit(symbol))
				{
					var value = CreateNumber(ref i, expression);
					stack.Push(value);
					continue;
				}
				if (symbol != ' ')
				{
					Operation(stack, symbol);
				}

			}
			return (stack.Pop().Item1, true);
		}

		/// <summary>
		/// Push to a stack result of expression
		/// </summary>
		/// <param name="stack"></Stack>
		/// <param name="operation"></Symbol containg operation : multiplication, addition, subtraction or division>
		private static void Operation(IStack stack, char operation)
		{
			int value1 = stack.Pop().Item1;
			int value2 = stack.Pop().Item1;

			if (operation == '+')
			{
				stack.Push(value2 + value1);
			}

			if (operation == '*')
			{
				stack.Push(value2 * value1);
			}

			if (operation == '-')
			{
				stack.Push(value2 - value1);
			}

			if (operation == '/')
			{
				stack.Push(value2 / value1);
			}
		}
	}
}