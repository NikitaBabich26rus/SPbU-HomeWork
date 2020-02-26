using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2._3
{
    class Calculator
    {

		private static IStack stack;

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

		public static int Counting(string expression, bool choice)
		{
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
			return stack.Pop();
		}

		private static void Operation(IStack stack, char operation)
		{
			int value1 = stack.Pop();
			int value2 = stack.Pop();

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
