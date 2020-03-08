using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._1
{
    public class Tree
    {
		private INode root { get; set; }

		public void buildTree(string str)
		{
			int counter = 0;
			root = AddElementInTree(str, ref counter);
		}

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

		public int Counting() => root.Counting();

		public int outputTree()
		{
			return Counting();
		}
	}
}
