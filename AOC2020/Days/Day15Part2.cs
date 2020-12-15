using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day15Part2
	{
		public Day15Part2()
		{
			int[] numberHistory = new int[30000000];
			// Test data
			// string[] inputString = "0,3,6".Split(',');
			// string[] inputString = "1,3,2".Split(',');
			// string[] inputString = "2,1,3".Split(',');
			// string[] inputString = "1,2,3".Split(',');
			// string[] inputString = "2,3,1".Split(',');
			// string[] inputString = "3,2,1".Split(',');
			// string[] inputString = "3,1,2".Split(',');
			
			// Real input
			string[] inputString = "20,0,1,11,6,3".Split(',');
			int[] input = Array.ConvertAll(inputString, int.Parse);

			int lastNumber = 0;
			int i = 1;
			foreach (int number in input)
			{
				lastNumber = number;
				numberHistory[lastNumber] = i++;
			}

			while(i <= 30000000)
			{
				int index = numberHistory[lastNumber];
				int n = index == 0 ? 0 : i - index - 1;
				numberHistory[lastNumber] = i++ - 1;
				lastNumber = n;
			}
			Console.WriteLine($"The last number was {lastNumber}");
		}
	}
}