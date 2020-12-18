using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Days
{
	public class Day18Part2
	{
		public Day18Part2()
		{
			string[] programList = Utils.LoadFileToStringArray("Day18-1.txt");

			string input = programList[0];
			long total = 0;
			int i = 0;
			while (true)
			{
				if (input.Contains("("))
				{
					input = HandleParentheses(input);
					continue;
				}
				
				input = DoMath(input, input);
				
				if(input.Contains('*') || input.Contains('+'))
					continue;
				
				total += long.Parse(input);
				i++;
				if (i < programList.Length)
				{
					input = programList[i];
					continue;
				}
				break;
			}
			Console.WriteLine($"The sum total is {total}");
		}

		private string HandleParentheses(string input)
		{
			char[] inputArray = input.ToCharArray();
			int counter = 0;
			int i = 0;
			for (i = 0; i < inputArray.Length; i++)
			{
				if (inputArray[i] == '(')
				{
					counter++;
					continue;
				}

				if (inputArray[i] == ')')
				{
					counter--;
					if (counter == 0)
						break;
				} 
			}
			int a = input.IndexOf('(');
			
			string c = input.Substring(a + 1, i - a - 1);

			while (true)
			{
				if (c.Contains('('))
				{
					string returnVal = HandleParentheses(c);
					input = input.Replace(c, returnVal);
					c = returnVal;
					continue;
				}
				break;
			}
			
			input = DoMath(input, c);
			
			return input;
		}

		private string DoMath(string input, string sum)
		{
			string copySum = sum;
			long total = 0;
			while (true)
			{
				string[] sumInfo = copySum.Split(" ");
				long sumTotal = 0;
				string subStrInner = "";
				if (sumInfo.Contains("+"))
				{
					int firstPlus = Array.IndexOf(sumInfo, "+");
					sumTotal = long.Parse(sumInfo[firstPlus - 1]) + long.Parse(sumInfo[firstPlus + 1]);
					subStrInner = sumInfo[firstPlus - 1] + " + " + sumInfo[firstPlus + 1]; 

				}
				else
				{
					sumTotal = long.Parse(sumInfo[0]) * long.Parse(sumInfo[2]);
					subStrInner = sumInfo[0] + " * " + sumInfo[2]; 

				}
				
				copySum = new Regex(Regex.Escape(subStrInner)).Replace(copySum, sumTotal.ToString(), 1);

				if(copySum.Contains('*') || copySum.Contains('+'))
					continue;

				total = sumTotal;
				break;
			}

			string testString = "(" + sum + ")";
			return input.Replace(input.Contains(testString) ? testString : sum, total.ToString());
		}
	}
}